using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PedidosApiWebApplication.BancoDeDados;
using PedidosApiWebApplication.Dtos_data_transfer_object_;
using PedidosApiWebApplication.Modelos;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PedidosApiWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly PedidosContext _context;

        public PedidosController(PedidosContext context)
        {
            _context = context;
        }

        // GET: api/Pedidos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidos()
        {
            //SELECT c.NumeroMesa, c.NomeCliente FROM Comandas WHERE SituacaoComanda = 1

            var resultPedidos = await _context.Pedidos
                .Include(p => p.itemPedidos)
                .Select(p => new PedidoGetDto
                {
                    idPedido = p.idPedido,
                    idCliente = p.idCliente,
                    dataPedido = p.dataPedido,
                    statusPedido = p.statusPedido,
                    valorTotalPedido = p.valorTotalPedido,
                    observacoesPedido = p.observacoesPedido,
                    itensPedido = p.itemPedidos.Select(ip => new ItensPedidoGetDto
                    {
                        idItemPedido = ip.idItemPedido,
                        nomeProduto = ip.Produto.nomeProduto,
                    }
                                    ).ToList()
                })
                .ToListAsync();
            //retorna o conteudo com a lista de comandas
            return Ok(resultPedidos);
        }

        // GET: api/Pedidos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoGetDto>> GetPedido(int id)
        {

            var resultPedidos = await _context.Pedidos
                .Include(p => p.itemPedidos)
                .Where(p => p.idPedido == id)
                .Select(p => new PedidoGetDto
                {
                    idCliente = p.idCliente,
                    dataPedido = p.dataPedido,
                    statusPedido = p.statusPedido,
                    valorTotalPedido = p.valorTotalPedido,
                    observacoesPedido = p.observacoesPedido,
                    itensPedido = p.itemPedidos.Select(ip => new ItensPedidoGetDto
                    {
                        idItemPedido = ip.idItemPedido,
                        nomeProduto = ip.Produto.nomeProduto,
                    }
                                    ).ToList()
                })
                .FirstOrDefaultAsync();

            if (resultPedidos == null)
            {
                return NotFound();
            }

            return resultPedidos;
        }

        // PUT: api/Pedidos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedido(int id, PedidoPutDto pedido)
        {

            var pedidoASerAtualizado = await _context.Pedidos
                .FirstAsync(p => p.idPedido == id);

            if(pedidoASerAtualizado == null)
            {
                return BadRequest("Pedido com esse id não existe...");
            }

            var clienteProcurarNoBanco = await _context.Clientes.FindAsync(pedido.idCliente);

            if(clienteProcurarNoBanco == null)
            {
                return BadRequest("Cliente com esse id não existe");
            }

            pedidoASerAtualizado.idCliente = pedido.idCliente;
            pedidoASerAtualizado.statusPedido = pedido.statusPedido;
            pedidoASerAtualizado.dataPedido = pedido.dataPedido;
            pedidoASerAtualizado.observacoesPedido = pedido.observacoesPedido;
            
            foreach(var item in pedido.itensPedido)
            {
                if(item.incluir == true)
                {
                    var novoItemPedido = new ItemPedido()
                    {
                        Pedido = pedidoASerAtualizado,
                        idProduto = item.idProduto
                    };

                    await _context.AddAsync(novoItemPedido);
                }
                if(item.excluir == true)
                {
                    var pedidoItemExcluir = await _context.ItemPedidos
                        .FirstAsync(pi => pi.idItemPedido == item.idItemPedido);
                    _context.ItemPedidos.Remove(pedidoItemExcluir);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // PUT: api/Pedidos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        // POST: api/Pedidos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pedido>> PostPedido(PedidoDto pedido)
        {
            // Verificar se o cliente existe
            var ClienteNoBanco = await _context.Clientes.FindAsync(pedido.idCliente);
            if (ClienteNoBanco == null)
            {
                return BadRequest("Cliente com esse id não existe...");
            }

            // Criar o novo pedido
            var novoPedido = new Pedido()
            {
                idCliente = pedido.idCliente,
                dataPedido = DateTime.Now,
                statusPedido = pedido.statusPedido,
                valorTotalPedido = pedido.valorTotalPedido,
                observacoesPedido = pedido.observacoesPedido,
            };

            // Adicionar o pedido e salvar para obter o idPedido
            await _context.Pedidos.AddAsync(novoPedido);
            await _context.SaveChangesAsync(); // Salvar para gerar o idPedido

            // Iterar sobre os itens do pedido
            foreach (var item in pedido.itensPedido)
            {
                // Verificar se o produto existe
                var produtoExistente = await _context.Produtos.FindAsync(item);
                if (produtoExistente == null)
                {
                    return BadRequest($"Produto com o id {item} não existe.");
                }

                // Criar e adicionar o item do pedido
                var novoItemComanda = new ItemPedido()
                {
                    idPedido = novoPedido.idPedido, // Associar ao pedido salvo
                    idProduto = item
                };

                await _context.ItemPedidos.AddAsync(novoItemComanda);
            }

            // Salvar os itens do pedido
            await _context.SaveChangesAsync();

            // Retornar o pedido criado
            return CreatedAtAction("GetPedido", new { id = novoPedido.idPedido }, pedido);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }

            // Remover os itens diretamente com SQL
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM ItemPedidos WHERE idPedido = {0}", id);

            // Remover o pedido
            _context.Pedidos.Remove(pedido);

            // Salvar as mudanças
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool PedidoExists(int id)
        {
            return _context.Pedidos.Any(e => e.idPedido == id);
        }
    }
}
