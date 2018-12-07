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

        // GET RECEICOES
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/refeicoes")]
        [Description("Obter todas as refeições do eNutrideal.")]
        List<Refeicao> GetRefeicao();

        // Get refeicao por restaurante
        [OperationContract(Name = "GetRefeicaoPorRestaurante")]
        [WebInvoke(Method = "GET", UriTemplate = "/refeicoes/{restaurante}")]
        [Description("Obter refeições de determinado restaurante.")]
        List<Refeicao> GetRefeicaoPorRestaurante(string restaurante);


        // Get refeicao por nome
        [OperationContract(Name = "GetRefeicaoPorItem")]
        [WebInvoke(Method = "GET", UriTemplate = "/refeicoes/{item}")]
        [Description("Obter o resultado de uma pesquisa através de Refeição/Item.")]
        List<Refeicao> GetRefeicaoPorItem(string item);

        // ADD REFEICAO , com instância da classe Refeição
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/refeicao")]
        [Description("Adicionar Refeição ao eNutrideal.")]
        void AddRefeicao(Refeicao refeicao);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/refeicoesToXML")]
        [Description("Adiciona lista de refeições contida no servidor no XML")]
        void addListRefeicoesToXML();

        [OperationContract]
        void recebeRefeicao(Refeicao refeicao);
        ////

        // ADD  SINGLE REFEICAO , através de strings e não uma instância de Refeição
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/refeicao2")]
        [Description("Adicionar Refeição ao eNutrideal.")]
        void CriaXML(string restaurante, string item, string quantidade, string calorias);

        // DELETE REFEICAO
        [OperationContract(Name = "ApagarRefeicaoPorItem")]
        [WebInvoke(Method = "DELETE", UriTemplate = "/refeicao/{item}")]
        [Description("Apagar refeicao por nome(item).")]
        void DeleteRefeicao(string item);

        //CALCULADORAS

        
        
        //PESO IDEAL
        [OperationContract]
        double CalcularPesoIdeal(int idade, int altura, string genero);

        //CALORIAS POR DIA
        [OperationContract]
        double CalcularCaloriasDia(int idade, string genero, int altura, double peso, string nivelAtividade);
        //PLANO CALORICO

        //[OperationContract]
        //int CalcularPlanoCalorico(int pesoIdeal, double caloriasDia);


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
        [DataMember]
        public static List<Refeicao> listRefeicoes = new List<Refeicao>();

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

    /*
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
        */
    }

