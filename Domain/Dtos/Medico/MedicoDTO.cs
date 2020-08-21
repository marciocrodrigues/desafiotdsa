using Api.Dtos;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class MedicoDTO : Notifiable, IBaseDTO
    {
        public MedicoDTO(){}

        public MedicoDTO(string nome, string cpf, string crm, List<string> especialidades)
        {
            Nome = nome;
            Cpf = cpf;
            Crm = crm;
            Especialidades = especialidades;
        }

		/// <summary>
		/// Nome do medico
		/// </summary>
        public string Nome { get; set; }
		/// <summary>
		/// CPF do medico
		/// Preencher com ponto e traço: 999.999.999-99
		/// </summary>
        public string Cpf { get; set; }
		/// <summary>
		/// CRM do medico
		/// </summary>
        public string Crm { get; set; }
		/// <summary>
		/// Especialidades do medico
		/// </summary>
        public List<string> Especialidades { get; set; }

        public void Validate()
        {
			AddNotifications(
				new Contract()
				.Requires()
				.IsNotNullOrEmpty(Nome, "Nome", "nome é obrigatorio")
				.AreEquals(ValidarCpf(Cpf), true, "Cpf", "cpf inválido")
				.IsNotNullOrEmpty(Crm, "Crm", "crm é obrigatorio")
				.AreEquals(Especialidades.Count > 0, true, "Especialidades", "Deve ser cadastrado ao menos uma especidade")
				.HasMaxLen(Nome, 255, "Nome", "nome não deve passar de 255 caracteres")
				.HasMaxLen(Cpf, 14, "Cpf", "cpf não deve passar de 14 caracteres")
				.HasMaxLen(Crm, 10, "Crm", "crm não deve passar de 1o caracteres")
			);
        }

		public bool ValidarCpf(string cpf)
		{
			int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			string tempCpf;
			string digito;
			int soma;
			int resto;
			cpf = cpf.Trim();
			cpf = cpf.Replace(".", "").Replace("-", "");
			if (cpf.Length != 11)
				return false;
			tempCpf = cpf.Substring(0, 9);
			soma = 0;

			for (int i = 0; i < 9; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = resto.ToString();
			tempCpf = tempCpf + digito;
			soma = 0;
			for (int i = 0; i < 10; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = digito + resto.ToString();
			return cpf.EndsWith(digito);
		}

	}
}
