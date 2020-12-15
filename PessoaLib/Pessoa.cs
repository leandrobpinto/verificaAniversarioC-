using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PessoaLib
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public DateTime DataAniversario { get; set; }
        
        public override string ToString()
        {
            return $"\nNome: {Nome} \nSobrenome: {SobreNome} \nData nascimento: {DataAniversario.Day}/{DataAniversario.Month}/{DataAniversario.Year} ";
        }


        public static string CalculaProximoAniversario(ListPessoa listP, int escolhePessoa)
        {
            if (listP.CalculaAniversario(listP.pessoas[escolhePessoa].DataAniversario) < 0)
            {
                DateTime date1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                DateTime date2 = new DateTime(DateTime.Now.Year +1, listP.pessoas[escolhePessoa].DataAniversario.Month, listP.pessoas[escolhePessoa].DataAniversario.Day);
                TimeSpan intervalProximoAniversario =  date1 - date2;
                return $"Esta pessoa já fez aniversario e faltam {-intervalProximoAniversario.Days} para sue proximo aniversario";
            }
            else if (listP.CalculaAniversario(listP.pessoas[escolhePessoa].DataAniversario) > 0)
            {
               return $"Faltam: {listP.CalculaAniversario(listP.pessoas[escolhePessoa].DataAniversario)} para seu aniversario";
            }
            else if (listP.CalculaAniversario(listP.pessoas[escolhePessoa].DataAniversario) == 0)
            {
                return "Seu aniversario é hoje";
            }
            return "";
        }

        public int CalculaAniversario(DateTime dataPessoa)
        {
            DateTime date1 = new DateTime(DateTime.Now.Year,DateTime.Now.Month ,DateTime.Now.Day);
            DateTime date2 = new DateTime(DateTime.Now.Year, dataPessoa.Month, dataPessoa.Day);
            TimeSpan interval = date2 - date1;
            return interval.Days;
        }
    }
}
