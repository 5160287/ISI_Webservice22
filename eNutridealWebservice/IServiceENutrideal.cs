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
        //testeeee2

        // GET RECEICOES
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/refeicoes")]
        [Description("Obter todas as refeições do eNutrideal.")]
        List<Refeicao> GetRefeicao();

        // Get refeicao por restaurante
        [OperationContract(Name = "GetRefeicaoPorRestaurante")]
        [WebInvoke(Method = "GET", UriTemplate = "/refeicoes/{restaurante}")]
        [Description("Obter refeições de determinado restaurante.")]
        List<Refeicao> GetRefeicao(string restaurante);

        // ADD SINGLE REFEICAO
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/refeicao")]
        [Description("Adicionar Refeição ao eNutrideal.")]
        void AddRefeicao(Refeicao refeicao);

        // ADD REFEICOES FROM DOCS, juntamente com o método "CriaXML"
        [OperationContract(Name = "ConverteParaXML")]
        [WebInvoke(Method = "GET", UriTemplate = "/refeicoesToXml")]
        [Description("Permite ao client passar a informalção parsed, e o servidor adiciona esses dados à BD constante de um doc XML")]
        void ConverteParaXML();

        // Método complementar do método "ConverteParaXML" ( recebe os atributos e produz o XML)
        [OperationContract]
        void CriaXML(string restaurante, string item, string quantidade, string calorias);

        //Operações que permitem passar a informação parsed do lado do client para o server
        [OperationContract]
        void RecebeItem(string item);
        [OperationContract]
        void RecebeRestaurante(string restaurante);
        [OperationContract]
        void RecebeCaloria(string caloria);
        [OperationContract]
        void RecebeQuantidade(string quantidade);

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

       


        

        


        /*
                [OperationContract]
                List<string> RecebeListaRestaurantes(List<string> listRestaurantes);

                [OperationContract]
                List<string> RecebeListaItems(List<string> listItems);

                [OperationContract]
                List<string> RecebeListaQuantidades(List<string> listQuantidades);

                [OperationContract]
                List<string> RecebesListaCalorias(List<string> listCalorias);
        */





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
        public static List<string> listRestaurantes = new List<string>();
        [DataMember]
        public static List<string> listItems = new List<string>();
        [DataMember]
        public static List<string> listQuantidades = new List<string>();
        [DataMember]
        public static List<string> listCalorias = new List<string>();

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
