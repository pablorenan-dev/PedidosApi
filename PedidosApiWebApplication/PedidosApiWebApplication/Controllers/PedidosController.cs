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
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);

            if (pedido == null)
            {
                return NotFound();
            }

            return pedido;
        }

        // PUT: api/Pedidos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedido(int id, Pedido pedido)
        {
            if (id != pedido.idPedido)
            {
                return BadRequest();
            }

            _context.Entry(pedido).State = EntityState.Modified;

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
            var novoPedido = new Pedido()
            {
                idCliente = pedido.idCliente,
                dataPedido = DateTime.Now,
                statusPedido = pedido.statusPedido,
                valorTotalPedido = pedido.valorTotalPedido,
                observacoesPedido = pedido.observacoesPedido,
            };

            await _context.Pedidos.AddAsync(novoPedido);
           

            foreach (var item in pedido.itensPedido)
            {
                //var cardapioItem = await _context.CardapioItems.FindAsync(comanda.CardapioItems[0]);
                var novoItemComanda = new ItemPedido()
                {
                    Pedido = novoPedido,
                    idProduto = item
                };

                // adicionando o novo item na comanda
                await _context.ItemPedidos.AddAsync(novoItemComanda);

                // verificar se o cardapio possui preparo
                // SELECT PossuiPreparo From Cardapioitem Where id = <item>
                // Find pode retornar nulo
                // First nao retorna nulo, pega sempre o primeiro

             
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPedido", new { id = novoPedido.idPedido }, pedido);
        }

        // DELETE: api/Pedidos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }

            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedidos.Any(e => e.idPedido == id);
        }
    }
}
