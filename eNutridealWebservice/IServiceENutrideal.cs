using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace eNutridealWebservice
{
    [ServiceContract]
    public interface IServiceENutrideal
    {
        //testeeee

        // GET RECEICOES

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/refeicoes")]
        [Description("Obter todas as refeições do eNutrideal.")]
        List<Refeicao> GetRefeicao();

        [OperationContract(Name = "GetRefeicaoPorRestaurante")]
        [WebInvoke(Method = "GET", UriTemplate = "/refeicoes/{restaurante}")]
        [Description("Obter refeições de determinado restaurante.")]
        List<Refeicao> GetRefeicao(string restaurante);

        // ADD REFEICAO
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/refeicao")]
        [Description("Adicionar Refeição ao eNutrideal.")]
        void AddRefeicao(Refeicao refeicao);

        // DELETE REFEICAO
        [OperationContract(Name = "ApagarRefeicaoPorItem")]
        [WebInvoke(Method = "DELETE", UriTemplate = "/refeicao/{item}")]
        [Description("Apagar refeicao por nome(item).")]
        void DeleteRefeicao(string item);

        //CALCULADORAS

        //PESO IDEAL
        [OperationContract]
        double calcularPesoIdeal(int idade, int altura, string genero);

        //CALORIAS POR DIA
        [OperationContract]
        double calcularCaloriasDia(int idade, string genero, int altura, double peso, string nivelAtividade);
        //PLANO CALORICO

    }


    [DataContract]
    public class Refeicao
    {
        public Refeicao(string restaurante, string item, string quantidade, string calorias)
        {
            this.Restaurante = restaurante;
            this.Item = item;
            this.Quantidade = quantidade;
            this.Calorias = calorias;
        }
        [DataMember]
        public string Restaurante { get; set; }
        [DataMember]
        public string Item { get; set; }
        [DataMember]
        public string Quantidade { get; set; }
        [DataMember]
        public string Calorias { get; set; }

        public override string ToString()
        {
            string res = string.Empty;
            res += "Restaurante: " + Restaurante + Environment.NewLine;
            res += "Item: " + Item + Environment.NewLine;
            res += "Quantidade: " + Quantidade + Environment.NewLine;
            res += "Calorias: " + Calorias + Environment.NewLine;
            return res;
        }
    }
    [DataContract]
    public class DadosPessoais
    {
        [DataMember]
        public int Idade { get; set; }

        [DataMember]
        public int Altura { get; set; }

        [DataMember]
        public double Peso { get; set; }

        [DataMember]
        public string Genero { get; set; }

        [DataMember]
        public string NivelAtividade { get; set; }
    }
}
