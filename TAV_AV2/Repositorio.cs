using System;
using System.Collections.Generic;
using System.Linq;
using System.Spatial;
using System.Text;
using System.Threading.Tasks;
using System.Device;
using System.Device.Location;

namespace TAV_AV2
{
    public static class Repositorio
    {
        public static bool RepositorioCarregado { get; set; } = false;
        public static List<Carro> Carros { get; set; }
        public static List<Cidade> Cidades { get; set; }
        public static List<Loja> Lojas { get; set; }

        public static void CarregarRepositorio()
        {
            if (!RepositorioCarregado)
            {
                Carros = new List<Carro>();
                Cidades = new List<Cidade>();
                Lojas = new List<Loja>();

                Cidades.Add(new Cidade { Id = 1, Nome = "Rio de Janeiro", CidadeCoordenadas = new GeoCoordinate(-22.9035, -43.2096) });
                Cidades.Add(new Cidade { Id = 2, Nome = "São Paulo", CidadeCoordenadas = new GeoCoordinate(-23.533773, -46.625290) });
                Cidades.Add(new Cidade { Id = 3, Nome = "Salvador", CidadeCoordenadas = new GeoCoordinate(-12.974722, -38.476665) });

                Lojas.Add(new Loja { Id = 1, Nome = "Aeroporto Santos Dumont", Cidade = Cidades.FirstOrDefault(c => c.Id == 1), LojaCoordenadas = new GeoCoordinate(-22.9103, -43.1631) });
                Lojas.Add(new Loja { Id = 2, Nome = "Aeroporto Tom Jobim", Cidade = Cidades.FirstOrDefault(c => c.Id == 1), LojaCoordenadas = new GeoCoordinate(-22.8089, -43.2436) });
                Lojas.Add(new Loja { Id = 3, Nome = "Aeroporto Congonhas", Cidade = Cidades.FirstOrDefault(c => c.Id == 2), LojaCoordenadas = new GeoCoordinate(-23.6267, -46.6553) });
                Lojas.Add(new Loja { Id = 4, Nome = "Loja Osasco", Cidade = Cidades.FirstOrDefault(c => c.Id == 2), LojaCoordenadas = new GeoCoordinate(-23.5325, -46.79167) });
                Lojas.Add(new Loja { Id = 5, Nome = "Aeroporto Internacional de Salvador", Cidade = Cidades.FirstOrDefault(c => c.Id == 3), LojaCoordenadas = new GeoCoordinate(-12.9704, -38.5124) });
                Lojas.Add(new Loja { Id = 6, Nome = "Loja Centro Salvador", Cidade = Cidades.FirstOrDefault(c => c.Id == 3), LojaCoordenadas = new GeoCoordinate(-12.9704, -38.5124) });

                Carros.Add(new Carro { Id = 1, Placa = "HJK-1234", Fabricante = "Fiat", Modelo = "Palio",
                Ano = 2010, Cor = "Preto", CarroStatus = CarroStatus.Livre, AlugadoComMotorista = false,
                PeriodoLocacao = PeriodoLocacao.NaoAlugado, DataInicioLocacao = null, DataFimLocacao = null,
                TipoLocacao = TipoLocacao.NaoAlugado, Loja = Lojas.FirstOrDefault(l => l.Id == 1) });

                Carros.Add(new Carro { Id = 2, Placa = "ERT-7894", Fabricante = "Fiat", Modelo = "Palio",
                Ano = 2010, Cor = "Branco", CarroStatus = CarroStatus.Reservado, AlugadoComMotorista = false,
                PeriodoLocacao = PeriodoLocacao.SeteDias, DataInicioLocacao = new DateTime(2020, 12, 1), DataFimLocacao = new DateTime(2020, 12, 7),
                TipoLocacao = TipoLocacao.Loja, Loja = Lojas.FirstOrDefault(l => l.Id == 1) });

                Carros.Add(new Carro { Id = 3, Placa = "CVB-7412", Fabricante = "Fiat", Modelo = "Uno",
                Ano = 2007, Cor = "Cinza", CarroStatus = CarroStatus.Livre, AlugadoComMotorista = false,
                PeriodoLocacao = PeriodoLocacao.NaoAlugado, DataInicioLocacao = null, DataFimLocacao = null,
                TipoLocacao = TipoLocacao.NaoAlugado, Loja = Lojas.FirstOrDefault(l => l.Id == 2) });

                Carros.Add(new Carro { Id = 4, Placa = "LKJ-6547", Fabricante = "Fiat", Modelo = "Uno",
                Ano = 2007, Cor = "Preto", CarroStatus = CarroStatus.Livre, AlugadoComMotorista = false,
                PeriodoLocacao = PeriodoLocacao.NaoAlugado, DataInicioLocacao = null, DataFimLocacao = null,
                TipoLocacao = TipoLocacao.NaoAlugado, Loja = Lojas.FirstOrDefault(l => l.Id == 3) });

                Carros.Add(new Carro { Id = 5, Placa = "WSX-3278", Fabricante = "Ford", Modelo = "Ka",
                Ano = 2014, Cor = "Azul", CarroStatus = CarroStatus.Livre, AlugadoComMotorista = false,
                PeriodoLocacao = PeriodoLocacao.NaoAlugado, DataInicioLocacao = null, DataFimLocacao = null,
                TipoLocacao = TipoLocacao.NaoAlugado, Loja = Lojas.FirstOrDefault(l => l.Id == 3) });

                Carros.Add(new Carro { Id = 6, Placa = "UYT-2341", Fabricante = "Ford", Modelo = "Ka",
                Ano = 2014, Cor = "Preto", CarroStatus = CarroStatus.Reservado, AlugadoComMotorista = false,
                PeriodoLocacao = PeriodoLocacao.QuinzeDias, DataInicioLocacao = new DateTime(2020, 12, 1), DataFimLocacao = new DateTime(2020, 12, 15),
                TipoLocacao = TipoLocacao.Telefone, Loja = Lojas.FirstOrDefault(l => l.Id == 4) });

                Carros.Add(new Carro { Id = 7, Placa = "ASD-5825", Fabricante = "Ford", Modelo = "Ka",
                Ano = 2014, Cor = "Preto", CarroStatus = CarroStatus.Livre, AlugadoComMotorista = false,
                PeriodoLocacao = PeriodoLocacao.NaoAlugado, DataInicioLocacao = null, DataFimLocacao = null,
                TipoLocacao = TipoLocacao.NaoAlugado, Loja = Lojas.FirstOrDefault(l => l.Id == 5) });

                Carros.Add(new Carro { Id = 8, Placa = "MNB-4725", Fabricante = "Fiat", Modelo = "Siena",
                Ano = 2012, Cor = "Branco", CarroStatus = CarroStatus.Reservado, AlugadoComMotorista = false,
                PeriodoLocacao = PeriodoLocacao.TrintaDias, DataInicioLocacao = new DateTime(2020, 12, 1), DataFimLocacao = new DateTime(2020, 12, 30),
                TipoLocacao = TipoLocacao.Internet, Loja = Lojas.FirstOrDefault(l => l.Id == 5) });

                Carros.Add(new Carro { Id = 9, Placa = "GAW-9845", Fabricante = "Fiat", Modelo = "Siena",
                Ano = 2012, Cor = "Branco", CarroStatus = CarroStatus.Livre, AlugadoComMotorista = false,
                PeriodoLocacao = PeriodoLocacao.NaoAlugado, DataInicioLocacao = null, DataFimLocacao = null,
                TipoLocacao = TipoLocacao.NaoAlugado, Loja = Lojas.FirstOrDefault(l => l.Id == 6) });
            }
        }
    }

    public enum CarroStatus
    {
        Livre,
        Alugado,
        Reservado,
        Manutencao,
        Todos
    }

    public enum PeriodoLocacao
    {
        SeteDias,
        QuinzeDias,
        TrintaDias,
        NaoAlugado
    }

    public enum TipoLocacao
    {
        Internet,
        Telefone,
        Loja,
        NaoAlugado
    }

    public class Carro
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Fabricante { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public string Cor { get; set; }
        public CarroStatus CarroStatus { get; set; }
        public bool AlugadoComMotorista { get; set; }
        public PeriodoLocacao PeriodoLocacao { get; set; }
        public DateTime? DataInicioLocacao { get; set; }
        public DateTime? DataFimLocacao { get; set; }
        public TipoLocacao TipoLocacao { get; set; }
        public Loja Loja { get; set; }
    }

    public class Cidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public GeoCoordinate CidadeCoordenadas { get; set; }
    }

    public class Loja
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Cidade Cidade { get; set; }
        public GeoCoordinate LojaCoordenadas { get; set; }
    }
}
