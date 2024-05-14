using Microsoft.EntityFrameworkCore;
using MvcCorePostgreAWSEC2.Data;
using MvcCorePostgreAWSEC2.Models;

namespace MvcCorePostgreAWSEC2.Repositories
{
    public class RepositoryDepartamentos
    {
        private DepartamentosContext context;
        public RepositoryDepartamentos(DepartamentosContext context)
        {
            this.context = context;
        }

        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            return await this.context.Departamentos.ToListAsync();
        }

        public async Task<Departamento> FindDepartamentoAsync(int id)
        {
            return await this.context.Departamentos.
                FirstOrDefaultAsync(x => x.IdDept == id);
        }

        public async Task InsertarDepartamentoAsyc(Departamento departamento)
        {
            departamento.IdDept = await GetMaxIdAsync();
            await this.context.Departamentos.AddAsync(departamento);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int iddept)
        {
            Departamento departamento =
                await this.FindDepartamentoAsync(iddept);
            this.context.Departamentos.Remove(departamento);
            await this.context.SaveChangesAsync();
        }

        private async Task<int> GetMaxIdAsync()
        {
            if (this.context.Departamentos.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await this.context.Departamentos.MaxAsync(x => x.IdDept) + 1;
            }
        }
    }
}
