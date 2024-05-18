package by.it;

import org.xml.sax.SAXException;

import javax.xml.XMLConstants;
import javax.xml.transform.Source;
import javax.xml.transform.stream.StreamSource;
import javax.xml.validation.Schema;
import javax.xml.validation.SchemaFactory;
import javax.xml.validation.Validator;
import java.io.File;
import java.io.IOException;

public class Validation {
    public void Valid(){
        String xmlFile = "files\\xml.xml";
        String xmlSchema = "files\\xml.xsd";
        Schema schema = null;
        SchemaFactory factory = SchemaFactory.newInstance(XMLConstants.W3C_XML_SCHEMA_NS_URI);

        try{
            schema = factory.newSchema(new File(xmlSchema));
            Validator validator = schema.newValidator();
            Source source = new StreamSource(xmlFile);
            validator.validate(source);
        } catch (IOException e) {
            System.out.println(e.getMessage()+ "!!!");
        } catch (SAXException e) {
            System.out.println(e.getMessage()+ "!!!");
        }
    }
}
