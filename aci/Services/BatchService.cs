using aci.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using tutorial.Data;

namespace aci.Services
{
    public interface ILoteService
    {
        Task CreateBatchesByOrder(Order order);
    }
    public class BatchService : ILoteService
    {
        private readonly ApplicationDbContext _context;

        public BatchService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateBatchesByOrder(Order order)
        {
            Random rnd = new();
            int batches = rnd.Next(1, 6);
            int amountByBatch = order.Amount / batches;
            for (int i = 0; i < batches; i++)
            {
                if (i == batches - 1) amountByBatch = order.Amount - (amountByBatch * (batches - 1));
                Batch batch = new()
                {
                    OrderId = order.Id,
                    Amount = amountByBatch
                };

                _context.Batches.Add(batch);
            }

            await _context.SaveChangesAsync();
        }

    }
}
