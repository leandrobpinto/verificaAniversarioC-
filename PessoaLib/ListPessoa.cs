using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PessoaLib
{
    public class ListPessoa : Pessoa
    {
        public bool existePessoa = true;
        public ListPessoa()
        {
            pessoas = new List<Pessoa>();
        }

        public List<Pessoa> pessoas { get; set; }

        public void CriaPessoa(Pessoa p)
        {
            this.pessoas.Add(p);
        }
        public void BuscaPessoa(String nomePessoa)
        {
            int contador = 0;
            foreach (var i in pessoas)
            {

                if (i.Nome.Contains(nomePessoa) || i.SobreNome.Contains(nomePessoa))
                {
                    
                    Console.WriteLine($"{contador} - {i.Nome} {i.SobreNome}");
                    this.existePessoa = false;
                }
                contador++;
            }
        }
        public void AbreTxt(ListPessoa listP, string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string[] posicoes;
                    posicoes = sr.ReadToEnd().Split(';');

                    for (int i = 2; i < posicoes.Count(); i += 3)
                    {


                        DateTime dataHoje = DateTime.Now;
                        DateTime dataConvertida;
                        DateTime.TryParseExact(posicoes[i], "dd/MM/yyyy", new CultureInfo("pt-BR"), DateTimeStyles.None, out dataConvertida);

                        if (dataConvertida.Day.Equals(dataHoje.Day) && (dataConvertida.Month.Equals(dataHoje.Month)))
                        {
                            Console.Write($"{posicoes[i - 2]} {posicoes[i - 1]} faz aniversario hoje");
                        }
                        Pessoa p = new Pessoa();
                        p.DataAniversario = dataConvertida;
                        p.SobreNome = posicoes[i - 1];
                        p.Nome = posicoes[i - 2];
                        listP.CriaPessoa(p);


                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("O txt não foi encontrado e será criado ao finalizar o programa");
            }
        }

        public void SalvaTxt(string caminho)
        {
            TextWriter tw = new StreamWriter(caminho);
            foreach (var item in pessoas)
            {
                tw.Write($"{item.Nome};{item.SobreNome};{item.DataAniversario.ToString("dd/MM/yyyy")};");
            }
            tw.Close();
        }
    }
}
