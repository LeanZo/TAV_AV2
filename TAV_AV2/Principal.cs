using System;
using System.Collections.Generic;
using System.Linq;
using System.Spatial;
using System.Text;
using System.Threading.Tasks;

namespace TAV_AV2
{
    public static class Principal
    {
        static void Main(string[] args)
        {
            Repositorio.CarregarRepositorio();

            Console.WriteLine("AV2 da disciplina 5TAV feito por Lucas Lean A. Nascimento (1810478300059) - 2020-2 Manhã");
            Console.ReadLine();
        }


        public static bool ReservarCarro(Carro carro, bool comMotorista, TipoLocacao tipoLocacao, DateTime dataInicio, DateTime dataFinal, PeriodoLocacao periodoLocacao)
        {
            if(carro.CarroStatus == CarroStatus.Livre)
            {
                carro.CarroStatus = CarroStatus.Reservado;
                carro.AlugadoComMotorista = comMotorista;
                carro.TipoLocacao = tipoLocacao;
                carro.DataInicioLocacao = dataInicio;
                carro.DataFimLocacao = dataFinal;
                carro.PeriodoLocacao = periodoLocacao;

                return true;
            } else
            {
                return false;
            }
        }

        public static Carro LocalizarCarro(string Placa)
        {
            return Repositorio.Carros.FirstOrDefault(car => car.Placa.ToUpper() == Placa.ToUpper());
        }

        public static List<Carro> ListarCarros(string NomeCidade = null, string NomeLoja = null, CarroStatus carroStatus = CarroStatus.Todos)
        {
            var carros = new List<Carro>();

            if(string.IsNullOrEmpty(NomeCidade) && string.IsNullOrEmpty(NomeLoja))
            {
                return carroStatus == CarroStatus.Todos ? Repositorio.Carros : Repositorio.Carros.Where(car => car.CarroStatus == carroStatus).ToList();
            }
            else if (string.IsNullOrEmpty(NomeCidade))
            {
                return carroStatus == CarroStatus.Todos ? Repositorio.Carros.Where(car => car.Loja.Nome == NomeLoja).ToList() : Repositorio.Carros.Where(car => car.Loja.Nome == NomeLoja && car.CarroStatus == carroStatus).ToList();
            }
            else if (string.IsNullOrEmpty(NomeLoja))
            {
                return carroStatus == CarroStatus.Todos ? Repositorio.Carros.Where(car => car.Loja.Cidade.Nome == NomeCidade).ToList() : Repositorio.Carros.Where(car => car.Loja.Cidade.Nome == NomeCidade && car.CarroStatus == carroStatus).ToList();
            } 
            else
            {
                return carroStatus == CarroStatus.Todos ? Repositorio.Carros.Where(car => car.Loja.Cidade.Nome == NomeCidade && car.Loja.Nome == NomeLoja).ToList() : Repositorio.Carros.Where(car => car.Loja.Cidade.Nome == NomeCidade && car.Loja.Nome == NomeLoja && car.CarroStatus == carroStatus).ToList();
            }
        }

        public static Carro LocalizarCarroMaisProximo(Loja loja)
        {
            return Repositorio.Carros.Where(car => car.CarroStatus == CarroStatus.Livre).OrderBy(car => car.Loja.LojaCoordenadas.GetDistanceTo(loja.LojaCoordenadas)).FirstOrDefault();
        }
    }
}
