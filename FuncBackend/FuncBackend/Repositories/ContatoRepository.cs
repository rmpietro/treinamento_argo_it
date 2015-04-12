using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.ModelBinding;

namespace FuncBackend.Repositories
{
    public class ContatoRepository
    {
        public async Task<int> CreateContato(Contato contato)
        {
            using (MainModelContainer db = new MainModelContainer())
            {
                db.ContatoSet.Add(contato);
                int result = await db.SaveChangesAsync();
                return result;
            }
        }

        public async Task<List<Contato>> GetAll()
        {
            using (MainModelContainer db = new MainModelContainer())
            {
                return await db.ContatoSet.ToListAsync();
            }
        }

        public async Task<Contato> GetContatoById(int? id)
        {
            using (MainModelContainer db = new MainModelContainer())
            {
                return await db.ContatoSet.FindAsync(id);
            }
        }

    }
}