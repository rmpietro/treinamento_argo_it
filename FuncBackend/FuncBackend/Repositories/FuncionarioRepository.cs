using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FuncBackend.Repositories
{
    public class FuncionarioRepository
    {
        public async Task<int> CreateFuncionario(Funcionario fun)
        {
            using (MainModelContainer db = new MainModelContainer())
            {
                db.FuncionarioSet.Add(fun);
                int result = await db.SaveChangesAsync();
                return result;
            }
        }

        public async Task<List<Funcionario>> GetAll()
        {
            using (MainModelContainer db = new MainModelContainer())
            {
                return await db.FuncionarioSet.ToListAsync();
            }
        }

        public async Task<Funcionario> GetFuncionarioById(int id)
        {
            using (MainModelContainer db = new MainModelContainer())
            {
                return await db.FuncionarioSet.FindAsync(id);
            }
        }

        public async Task<Funcionario> GetFuncionarioByEmail(string email)
        {
            using (MainModelContainer db = new MainModelContainer())
            {
                return await db.FuncionarioSet.Where(f => f.Email.Equals(email)).FirstOrDefaultAsync();
            }
        }

        public async Task<int> UpdateFuncionario(Funcionario fun)
        {
            using (MainModelContainer db = new MainModelContainer())
            {
                int result = 0;
                var funcionario = db.FuncionarioSet.Find(fun.Id);
                if (funcionario != null)
                {
                    funcionario.Email = fun.Email;
                    funcionario.Nome = fun.Nome;
                    funcionario.Telefone = fun.Telefone;
                    result = await db.SaveChangesAsync();
                }
               
                return result;
            }
        }

        public async Task<int> DeleteFuncionario(int id)
        {
            using (MainModelContainer db = new MainModelContainer())
            {
                int result = 0;
                var funcionario = db.FuncionarioSet.Find(id);
                if (funcionario != null)
                {
                    db.FuncionarioSet.Remove(funcionario);
                    result = await db.SaveChangesAsync();
                }
                return result;
            }
        }
    }
}