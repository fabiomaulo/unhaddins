import java.util.List;

import org.dom4j.*;
import org.dom4j.io.SAXReader;
import org.hibernate.hql.ast.HqlParser;
import antlr.collections.AST;

public class GenerateHibernateResults 
{
   public static void main(String[] args) throws Exception 
   {
      Document document = getDocument("../TestQueries.xml");

      System.out.println("<Tests>");

      List<Node> testGroups = document.selectNodes("/Tests/TestGroup");
      for (Node testGroup : testGroups)
      {
         String name = testGroup.valueOf("@Name");
         String desc = testGroup.valueOf("Description");
       
         System.out.println("   <TestGroup Name=\"" + name + "\">");

         if (desc != null)
         {
            System.out.println("      <Description>" + desc + "</Description>");
         }  

         List<Node> tests = testGroup.selectNodes("Test");

         for (Node test : tests)
         {
            String ignore = test.valueOf("@Ignore");
            String query = test.valueOf("Query");
            desc = test.valueOf("Description");

            if (ignore == null || ignore == "")
            {
               System.out.println("      <Test>");
            } 
            else
            {
               System.out.println("      <Test Ignore=\"" + ignore + "\">");
            } 


            if (desc != null && desc != "")
            {
               System.out.println("         <Description>" + desc + "</Description>");
            }  

            System.out.println("         <Query><![CDATA[" + query + "]]></Query>");

            System.out.println("         <Result><![CDATA[" + Parse(query).toStringTree() + "]]></Result>");

            System.out.println("      </Test>");
         }

         System.out.println("   </TestGroup>");

      }

      System.out.println("</Tests>");
   }


   static AST Parse(String hql) throws Exception
   {
      HqlParser parser = HqlParser.getInstance( hql );

      parser.setFilter( false );
      parser.statement();
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