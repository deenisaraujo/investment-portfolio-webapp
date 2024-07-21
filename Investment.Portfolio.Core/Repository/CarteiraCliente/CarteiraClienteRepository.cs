using Investment.Portfolio.Core.Factory.Interface;
using Investment.Portfolio.Core.Factory;
using Investment.Portfolio.Core.Model;
using Investment.Portfolio.Core.Repository.CarteiraCliente.Interface;
using Dapper;
using Investment.Portfolio.Core.Dto;

namespace Investment.Portfolio.Core.Repository.CarteiraCliente
{
    public class CarteiraClienteRepository : ICarteiraClienteRepository
    {
        private readonly string QueryListarCarteira = "SELECT DS_ATIVO, DS_TIPO_PRODUTO, VL_PRECO, sum(IF(DS_TIPO_OPERACAO = 'Compra', NR_QUANTIDADE, -NR_QUANTIDADE)) AS NR_QUANTIDADE, sum(IF(DS_TIPO_OPERACAO = 'Compra', VL_OPERACAO, -VL_OPERACAO)) AS VL_POSICAO FROM invest_portf.TB_ORDEM";
        private readonly string QueryAtualizarCarteira = "";
        private readonly IConnectionFactory _factory;
        public CarteiraClienteRepository(IConnectionFactory factory)
        {
            _factory = factory;
        }

        public async Task<IEnumerable<CarteiraModel>> ListarCarteiraCliente(long cpfCnpj)
        {
            try
            {
                using (var conn = _factory.CreateConnection(DataBaseConnection.INVEST_PORTF))
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        cmd.CommandText = QueryListarCarteira + $" WHERE NR_CPF_CNPJ = {cpfCnpj} GROUP BY DS_ATIVO, DS_TIPO_PRODUTO,VL_PRECO ORDER BY DS_ATIVO;";
                        var result = await conn.QueryAsync<CarteiraDto>(cmd.CommandText);
                        return result.Select(x => x.toModel());
                    }
                }
            }
            catch (Exception)
            {
                return Enumerable.Empty<CarteiraModel>();
            }
        }
    }
}
