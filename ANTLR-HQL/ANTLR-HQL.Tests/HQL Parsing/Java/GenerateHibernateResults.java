import java.util.List;
import java.io.*;
import org.dom4j.*;
import org.dom4j.io.SAXReader;
import org.hibernate.hql.ast.HqlParser;
import antlr.collections.AST;
import org.hibernate.hql.ast.util.NodeTraverser;
import org.hibernate.hql.ast.QueryTranslatorImpl;

public class GenerateHibernateResults 
{
   public static void main(String[] args) throws Exception 
   {
      PrintStream out = new PrintStream("../TestQueriesWithResults.xml", "UTF-8");
      
      Document document = getDocument("../TestQueries.xml");

      out.println("<Tests>");

      List<Node> testGroups = document.selectNodes("/Tests/TestGroup");
      for (Node testGroup : testGroups)
      {
         String name = testGroup.valueOf("@Name");
         String desc = testGroup.valueOf("Description");
       
         out.println("   <TestGroup Name=\"" + name + "\">");

         if (desc != null)
         {
            out.println("      <Description>" + desc + "</Description>");
         }  

         List<Node> tests = testGroup.selectNodes("Test");

         for (Node test : tests)
         {
            String ignore = test.valueOf("@Ignore");
            String query = test.valueOf("Query");
            desc = test.valueOf("Description");

            if (ignore == null || ignore == "")
            {
               out.println("      <Test>");
            } 
            else
            {
               out.println("      <Test Ignore=\"" + ignore + "\">");
            } 


            if (desc != null && desc != "")
            {
               out.println("         <Description>" + desc + "</Description>");
            }  

            out.println("         <Query><![CDATA[" + query + "]]></Query>");

            String result;
            try
            {
               result = Parse(query).toStringTree();
            }
            catch (Exception e)
            {
               result = "Exception " + e.getMessage();
            }

            out.println("         <Result><![CDATA[" + result + "]]></Result>");

            out.println("      </Test>");
         }

         out.println("   </TestGroup>");

      }

      out.println("</Tests>");
   }


   static AST Parse(String hql) throws Exception
   {
      HqlParser parser = HqlParser.getInstance( hql );

      parser.setFilter( false );
      parser.statement();
      
      QueryTranslatorImpl.JavaConstantConverter converter = new QueryTranslatorImpl.JavaConstantConverter();
      NodeTraverser walker = new NodeTraverser( converter );
      walker.traverseDepthFirst( parser.getAST() );
		
	  parser.getParseErrorHandler().throwQueryException();
		
      return parser.getAST();
   }

   public static Document getDocument( final String xmlFileName )
   {
      Document document = null;
      SAXReader reader = new SAXReader();
      try
      {
         document = reader.read( xmlFileName );
      }
      catch (Exception e)
      {
         e.printStackTrace();
      }
      return document;
   }

}