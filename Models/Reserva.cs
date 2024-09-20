namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        private int _diasReservados;
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados
        {
            get => _diasReservados;
            set
            {
                if (value <= 0)//Tratamento para que a quantidade de dias reservados não seja igual ou menor a zero
                {
                    throw new ArgumentException("Número de dias reservados inválido");
                }
                _diasReservados = value;
            }
        }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido

            if (Suite.Capacidade > hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                throw new ArgumentException("Número de hospedes excedeu a capacidade da suite");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            if (DiasReservados >= 10)
            {
                decimal desconto = valor * 10 / 100;
                valor -= desconto;
            }

            return valor;
        }
    }
}