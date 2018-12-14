using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Hosting;
using System.Xml;

namespace eNutridealWebservice
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ServiceENutrideal : IServiceENutrideal
    {
        private static string FILEPATH;

        public ServiceENutrideal()
        {
            FILEPATH = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data",
           "refeicoes.xml");
        }
        public List<Refeicao> GetRefeicao()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATH);
            List<Refeicao> refeicoes = new List<Refeicao>();
            XmlNodeList refeicoesNodes = doc.SelectNodes("/refeicoes/refeicao");
            foreach (XmlNode refeicaoNode in refeicoesNodes)
            {
                XmlNode restauranteNode = refeicaoNode.SelectSingleNode("restaurante");
                XmlNode itemNode = refeicaoNode.SelectSingleNode("item");
                XmlNode quantidadeNode = refeicaoNode.SelectSingleNode("quantidade");
                XmlNode caloriasNode = refeicaoNode.SelectSingleNode("calorias");
                Refeicao refeicao = new Refeicao(
                restauranteNode.InnerText,
                itemNode.InnerText,
                quantidadeNode.InnerText,
                caloriasNode.InnerText
                );
                refeicoes.Add(refeicao);
            }
            return refeicoes;
        }
        public List<Refeicao> GetRefeicaoPorRestaurante(string restaurante)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATH);
            XmlNodeList refeicaoNodes = doc.SelectNodes("/refeicoes/refeicao[restaurante='" + restaurante +
           "']");
            List<Refeicao> refeicoes = new List<Refeicao>();
            foreach (XmlNode refeicaoNode in refeicaoNodes)
            {

                XmlNode restauranteNode = refeicaoNode.SelectSingleNode("restaurante");
                XmlNode itemNode = refeicaoNode.SelectSingleNode("item");
                XmlNode quantidadeNode = refeicaoNode.SelectSingleNode("quantidade");
                XmlNode caloriasNode = refeicaoNode.SelectSingleNode("calorias");
                Refeicao refeicao = new Refeicao(
                restauranteNode.InnerText,
                itemNode.InnerText,
                quantidadeNode.InnerText,
                caloriasNode.InnerText
                );
                refeicoes.Add(refeicao);
            }
            return refeicoes;
        }


        public List<Refeicao> GetRefeicaoPorItem(string item)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATH);
            //XmlNode refeicao = doc.SelectSingleNode("/refeicoes/refeicao[item='" + item +"']");
            // return refeicao;
            XmlNodeList refeicaoNodes = doc.SelectNodes("/refeicoes/refeicao[item='" + item +
           "']");
            List<Refeicao> refeicoes = new List<Refeicao>();
            foreach (XmlNode refeicaoNode in refeicaoNodes)
            {

                XmlNode restauranteNode = refeicaoNode.SelectSingleNode("restaurante");
                XmlNode itemNode = refeicaoNode.SelectSingleNode("item");
                XmlNode quantidadeNode = refeicaoNode.SelectSingleNode("quantidade");
                XmlNode caloriasNode = refeicaoNode.SelectSingleNode("calorias");
                Refeicao refeicao = new Refeicao(
                restauranteNode.InnerText,
                itemNode.InnerText,
                quantidadeNode.InnerText,
                caloriasNode.InnerText
                );
                refeicoes.Add(refeicao);
            }
            return refeicoes;
        }

        public void AddRefeicao(Refeicao refeicao)
        {
           
            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATH);
            XmlNode refeicoesNode = doc.SelectSingleNode("/refeicoes");
            XmlElement refeicaoNode = doc.CreateElement("refeicao");
            XmlElement restauranteNode = doc.CreateElement("restaurante");
            restauranteNode.InnerText = refeicao.Restaurante;
            refeicaoNode.AppendChild(restauranteNode);
            XmlElement itemNode = doc.CreateElement("item");
            itemNode.InnerText = refeicao.Item;
            refeicaoNode.AppendChild(itemNode);
            XmlElement quantidadeNode = doc.CreateElement("quantidade");
            quantidadeNode.InnerText = refeicao.Quantidade;
            refeicaoNode.AppendChild(quantidadeNode);
            XmlElement caloriasNode = doc.CreateElement("calorias");
            caloriasNode.InnerText = refeicao.Calorias;
            refeicaoNode.AppendChild(caloriasNode);
            refeicoesNode.AppendChild(refeicaoNode);
            doc.Save(FILEPATH);
           
            
        }

        public void recebeRefeicao(Refeicao refeicao)
        {
            Refeicao.listRefeicoes.Add(refeicao);
        }

        public void addListRefeicoesToXML()
        {
            for (int i = 0; i <= Refeicao.listRefeicoes.Count - 1; i++)
            {
                AddRefeicao(Refeicao.listRefeicoes[i]);
            }
            Refeicao.listRefeicoes.Clear();
        }

        public void CriaXML(string restaurante, string item, string quantidade, string calorias)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATH);
            XmlNode refeicoesNode = doc.SelectSingleNode("/refeicoes");
            XmlElement refeicaoNode = doc.CreateElement("refeicao");
            XmlElement restauranteNode = doc.CreateElement("restaurante");
            restauranteNode.InnerText = restaurante;
            refeicaoNode.AppendChild(restauranteNode);
            XmlElement itemNode = doc.CreateElement("item");
            itemNode.InnerText = item;
            refeicaoNode.AppendChild(itemNode);
            XmlElement quantidadeNode = doc.CreateElement("quantidade");
            quantidadeNode.InnerText = quantidade;
            refeicaoNode.AppendChild(quantidadeNode);
            XmlElement caloriasNode = doc.CreateElement("calorias");
            caloriasNode.InnerText = calorias;
            refeicaoNode.AppendChild(caloriasNode);
            refeicoesNode.AppendChild(refeicaoNode);
            doc.Save(FILEPATH);
        }

        public void DeleteRefeicao(string item) {
            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATH);
            XmlNode refeicoesNode = doc.SelectSingleNode("/refeicoes");
            XmlNode refeicaoNode = doc.SelectSingleNode("/refeicoes/refeicao[item='" + item + "']");
            if (refeicaoNode != null)
            {
                refeicoesNode.RemoveChild(refeicaoNode);
                doc.Save(FILEPATH);
            }
        }


        public string CalcularPlanoCalorico(double peso, double pesoIdeal, double caloriasDiaParaManter)
        {
            double calorias;
            double semanas;
            double plano;
            double diferençaPesos;
            string resultado="";
            double semanasAbsolutas;
            double semanasArredondadas;

            if (peso> pesoIdeal)
            {
                plano = caloriasDiaParaManter - 500;
                diferençaPesos = pesoIdeal - peso;
                semanas = diferençaPesos / 0.5;
                semanasAbsolutas = Math.Abs(semanas);
                semanasArredondadas = Math.Round(semanasAbsolutas, MidpointRounding.AwayFromZero);
                resultado = "De forma a que emagreça 0,5kg por semana deverá consumir "+ plano +" calorias/dia durante " + semanasArredondadas + " semanas para atingir o seu peso ideal";

                
            }
            if (peso < pesoIdeal)
            {
                plano = caloriasDiaParaManter + 500;
                diferençaPesos = pesoIdeal - peso;
                semanas = diferençaPesos / 0.5;
                semanasAbsolutas = Math.Abs(semanas);
                semanasArredondadas = Math.Round(semanasAbsolutas, MidpointRounding.AwayFromZero);
                resultado = "De forma a que engorde 0,5kg por semana deverá consumir " + plano + " calorias/dia durante " + semanasArredondadas + " semanas para atingir o seu peso ideal";
            }

            if (peso == pesoIdeal)
            {
                plano = caloriasDiaParaManter;
                diferençaPesos = pesoIdeal - peso;
                semanas = diferençaPesos / 0.5;
                Math.Abs(semanas);
                resultado = "Já se encontra no seu peso ideal , deverá consumir " + plano + " calorias por dia para o manter";
            }

            return resultado;
        }



        public double CalcularPesoIdeal(int idade, int altura, string genero)
        {
            double resultado_final = 0;
            if (genero.Equals("Masculino"))
            {

                if (altura <= 152.4)
                {
                    resultado_final = 52;
                }
                else
                {
                    resultado_final = 52 + (0.7480) * (altura - 152.4);
                }
            }

            if (genero.Equals("Feminino"))
            {

                if (altura <= 152.4)
                {
                    resultado_final = 49;
                }
                else
                {
                    resultado_final = 49 + (0.66929) * (altura - 152.4);
                }
            }
            return resultado_final;
        }

        public double CalcularCaloriasDia(int idade, string genero, int altura, double peso, string nivelAtividade)
        {
            double resultado_incompleto = 0;
            double resultado_final = 0;

            if (genero.Equals("Masculino"))
            {

                resultado_incompleto = 10 * peso + 6.25 * altura - 5 * idade + 5;

                //10xpeso +6.25 x altura – 5 x idade + 5;
            }
            else
            {
                resultado_incompleto = 10 * peso + 6.25 * altura - 5 * idade - 161;
            }


            if (nivelAtividade.Equals("Sedentário"))
            {
                resultado_final = resultado_incompleto * 1.2;
            }

            if (nivelAtividade.Equals("Ligeiramente Ativo(a)"))
            {
                resultado_final = resultado_incompleto * 1.375;
            }

            if (nivelAtividade.Equals("Moderadamente Ativo(a)"))
            {
                resultado_final = resultado_incompleto * 1.550;
            }

            if (nivelAtividade.Equals("Muito Ativo(a)"))
            {
                resultado_final = resultado_incompleto * 1.725;
            }

            if (nivelAtividade.Equals("Extraordinariamente Ativo(a)"))
            {
                resultado_final = resultado_incompleto * 1.9;
            }

            return resultado_final;
        }

        

    }
}
