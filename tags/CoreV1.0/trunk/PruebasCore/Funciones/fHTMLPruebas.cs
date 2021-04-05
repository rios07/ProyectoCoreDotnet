using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasCore.Funciones
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class FHTMLPruebas
    {
        [TestMethod]
        public void TestTd()
        {
            string texto = "spoiler";
            string textoBold = "<b>" + texto + "</b>";
            string style = "";
            string styleCompleto = "\"background-color: powderblue;\"";
            string devuelvo = "<td style=\"\"" + ">" + texto + "</td>";
            string devuelvoNoStyle = "<td>" + texto + "</td>";
            string devuelvoNoBoldStyle = "<td style=" + styleCompleto + ">" + texto + "</td>";
            string devuelvoBoldStyle = "<td style=" + styleCompleto + ">" + textoBold + "</td>";
            string devuelvoBoldNoStyle = "<td style=\"\"" + style + ">" + textoBold + "</td>";
            //Si es no bold no style
            Console.WriteLine(devuelvo + "\n" + FuncionesCore.FHTML.Td("spolier", "", false));
            //si es no bold style
            Console.WriteLine(devuelvoNoBoldStyle + "\n" + FuncionesCore.FHTML.Td("spolier", "background-color: powderblue;", false));
            //Assert.AreEqual(devuelvo, FuncionesCore.FHTML.Td("spolier", "background-color: powderblue;", false));
            //si es bold y no style
            Console.WriteLine(devuelvoBoldNoStyle + "\n" + FuncionesCore.FHTML.Td("spolier", "", true));
            //si es bold y style
            Console.WriteLine(devuelvoBoldStyle + "\n" + FuncionesCore.FHTML.Td("spolier", "background-color: powderblue;", true));

        }

        [TestMethod]
        public void TestTh()
        {
            string texto = "spoiler";
            int colspan = 1;
            string styleCompleto = "\"background-color: powderblue;\"";
            string textoBold = "<b>" + texto + "</b>";
            string devuelvoBoldStyle = "<th " + "colspan=\"" + colspan + "\"" + " style=" + styleCompleto + ">" + textoBold + "</th>";
            //si es bold y style
            Console.WriteLine(devuelvoBoldStyle + "\n" + FuncionesCore.FHTML.Th("spolier", "background-color: powderblue;", true, 1));
            Assert.ReferenceEquals(devuelvoBoldStyle, FuncionesCore.FHTML.Th("spolier", "background-color: powderblue;", true, 1));
        }

        [TestMethod]
        public void TestLinkAdministrar()
        {
            Console.WriteLine("<a href=\"www.google.com" + "\">Administrar</a>", "\n");
            Console.WriteLine(FuncionesCore.FHTML.LinkAdministrar("www.google.com"));

        }

        [TestMethod]
        public void TestLinkAdd()
        {
            Console.WriteLine("<a href=\"www.google.com" + "\">Agregar</a>");
            Console.WriteLine(FuncionesCore.FHTML.LinkAdd("www.google.com"));
        }

        [TestMethod]
        public void TestLinkGraficos()
        {
            Console.WriteLine("<a href=\"www.akal.com/autor/michel-foucault" + "\">Gráficos</a>");
            Console.WriteLine(FuncionesCore.FHTML.LinkGraficos("www.akal.com/autor/michel-foucault"));
        }

        [TestMethod]
        public void TestLinkListado()
        {
            Console.WriteLine("<a href=\"www.akal.com/autor/michel-foucaults" + "\">Listado</a>");
            Console.WriteLine(FuncionesCore.FHTML.LinkListado("www.akal.com/autor/michel-foucault"));
        }

        [TestMethod]
        public void TestLinkMapa()
        {
            //Console.WriteLine("<a href=\"www.google.com" + ">Administrar</a>".ToCharArray().ToString();
            //List<Byte> asciiBytes = Encoding.ASCII.GetBytes("<a href=\"www.google.com" + ">Administrar</a>").ToList();
            //asciiBytes.ForEach(c => Console.Write(" " + c));
            Console.WriteLine("<a href=\"www.akal.com/autor/michel-foucaults" + "\">Mapa</a>");
            Console.WriteLine(FuncionesCore.FHTML.LinkMapa("www.akal.com/autor/michel-foucault"));
        }

        [TestMethod]
        public void TestLinkSelected()
        {
            Console.WriteLine("<a href=\"www.iatasa.com/Intranet/HDT_Selected.aspx?registro=1" + "\">Abrir el registro</a>");
            Console.WriteLine(FuncionesCore.FHTML.LinkSelected("www.iatasa.com/Intranet/HDT_Selected.aspx", "1"));
        }

        [TestMethod]
        public void TestLink()
        {
            //sin param
            Console.WriteLine("<a href=\"www.iatasa.com/Intranet/HDT_Selected.aspx" + "\">Abrir el registro</a>");
            Console.WriteLine(FuncionesCore.FHTML.Link("www.iatasa.com/Intranet/HDT_Selected.aspx", "Abrir el registro"));
            //Con param
            Console.WriteLine("<a href=\"www.iatasa.com/Intranet/HDT_Selected.aspx?registro=1" + "\">Abrir el registro</a>");
            Console.WriteLine(FuncionesCore.FHTML.Link("www.iatasa.com/Intranet/HDT_Selected.aspx","Abrir el registro", "1"));
        }

        [TestMethod]
        public void TestMailTo()
        {
            Console.WriteLine("<a href=mailto:" + "ThundercatsRLZ@yahoo.com" + "?subject=" + "New thundercats" + ">" + "New thundercats on CN" + "</a>");
            Console.WriteLine(FuncionesCore.FHTML.MailTo("ThundercatsRLZ@yahoo.com", "New thundercats on CN", "New thundercats"));
            Console.WriteLine("///////////////////////////////////////////////////////////////////////////////////////");
            Console.WriteLine("<a href=mailto:" + "ThundercatsRLZ@yahoo.com" + "?subject=" + "New thundercats"+ "&body=" + "Cuerpazo" + ">" + "New thundercats on CN" + "</a>");
            Console.WriteLine(FuncionesCore.FHTML.MailTo("ThundercatsRLZ@yahoo.com", "New thundercats on CN", "Cuerpazo","New thudnercats"));
        }
        [TestMethod]
        public void TestLinkcCss()
        {
            Console.WriteLine("<a class=\"" + "ALGOCSS" + "\" &  href=\"" + "url.com" + "\" >" + "untexto" + "</a>");
            Console.WriteLine(FuncionesCore.FHTML.LinkcCSS("url.com","untexto","ALGOCSS"));
            Console.WriteLine("<a class=\"" + "ALGOCSS" + "\" &  href=\"" + "url.com" + "?Registro=" + "Regristro" + "\" >" + "untexto" + "</a>");
            Console.WriteLine(FuncionesCore.FHTML.LinkcCSS("url.com","untexto","ALGOCSS","Resgistro"));
        }

        [TestMethod]
        public void TestlinkTBlank()
        {
            Console.WriteLine("<a Target=\"_blank\" href=\"" + "superurl.com" + "\" >" + "untexto" + "</a>");
            Console.WriteLine(FuncionesCore.FHTML.LinkTBlank("superurl.com","untexto"));
            Console.WriteLine("<a Target=\" _blank\" href=\"" + "superurl.com" + "?Registro=" + "altoregistro" + "\" >" + "Flojotexto" + "</a>");
            Console.WriteLine(FuncionesCore.FHTML.LinkTBlank("superurl.com","Flojotexto","altoregistro"));
        }

        [TestMethod]
        public void TestLinktBlanckCSS()
        {
            Console.WriteLine("<a class=\"" + "ELCSS" + "\" & Target=\" _blank\" href=\"" + "Megaurl.com" + "\" >" + "elmejortexto" + "</a>");
            Console.WriteLine(FuncionesCore.FHTML.LinkTBlankcCSS("Megaurl.com","elmejortexto","ELCSS"));
            Console.WriteLine("<a class=\"" + "DACSS" + "\" & Target=\" _blank\" href=\"" + "OGurl.com" + "?Registro=" + "Registromal" + "\" >" + "textopromedio" + "</a>");
            Console.WriteLine(FuncionesCore.FHTML.LinkTBlankcCSS("OGurl.com","textopromedio","DACSS","registronormal"));
        }
    }
}
