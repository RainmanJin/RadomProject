using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Microsoft.Win32;

namespace PublicRandomData.Units
{
    enum PDFFONTFAMILY
    {
        微软雅黑 = 0,
        宋体 = 1,
        幼圆 = 2,
        方正悬针篆变简体 = 3
    }
    public class PDFTool
    {
        static Font LoadDefaultFont(PDFFONTFAMILY _font,int _size)
        {
            string _path= "../../Fonts/STXINGKA.TTF"; 
            switch(_font)
            {
                case PDFFONTFAMILY.宋体:
                    _path= "../../Fonts/SIMFANG.TTF";
                    break;
                case PDFFONTFAMILY.幼圆:
                    _path = "../../Fonts/SIMYOU.TTF";
                    break;
                case PDFFONTFAMILY.微软雅黑:
                    _path = "../../Fonts/MSYH.ttf";
                    break;
                case PDFFONTFAMILY.方正悬针篆变简体:
                    _path = "../../Fonts/FZXZZ.TTF";
                    break;
                default:
                    _path = "../../Fonts/SIMSUN.TTF";
                    break;

            }
            BaseFont font = BaseFont.CreateFont(_path, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            Font _f= new Font(font, _size);
            return _f;
        }
        public static void CreateDemo(string _path,string _pdf_content)
        {
            Font f = LoadDefaultFont(PDFFONTFAMILY.微软雅黑, 10);
            if (string.IsNullOrEmpty(_path))
            {
                return;
            }
            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(_path, FileMode.Create));
            doc.Open();
            for (int i = 0; i < 50; i++)
            {
                doc.NewPage();
                Paragraph paragraph = new Paragraph(_pdf_content, f);
                doc.Add(paragraph);
            }
            doc.Close();
        }
        static Phrase GetPhrase(string content, PDFFONTFAMILY f,int size)
        {
            Font _font = LoadDefaultFont(f, size);
            return new Phrase(content, _font);
        }
        static Document SetDefaultDocument()
        {
            Rectangle pageSize = PageSize.A4.Rotate();
            Document _doc = new Document(pageSize);
            _doc.AddTitle("测试PDF文件");
            _doc.AddSubject("Demo of PDF");
            _doc.AddKeywords("pdf,demo,semple");
            _doc.AddCreator("北京对啊网");
            _doc.AddAuthor("Rain.Wuu");
            _doc.SetMargins(0, 0, 60, 60);
            _doc.AddHeader("PDF Header", "the content of pdf file's header.");
            return _doc;
        }

        static void AddWatermake(Document doc,PdfWriter _write,Image img,string txt)
        {
            float _w = doc.Right-doc.Left;
            float _h = doc.Top-doc.Bottom;            
            PdfTemplate template = PdfTemplate.CreateTemplate(_write, _w, _h);
            img.GrayFill = 100;
            img.SetAbsolutePosition(_w / 2 - (img.Width / 2), _h / 2 - (img.Height / 2));
            template.AddImage(img, img.Width, 0, 0, img.Height, 0,0);
            //ColumnText.ShowTextAligned(template, Element.ALIGN_CENTER, GetPhrase(txt, PDFFONTFAMILY.宋体, 12), _w / 2, _h / 2, 30);
            doc.Add(Image.GetInstance(template));
        }

        public static void CreateTablePdf(string _path,string _content)
        {
            string _img = @"../../Imgs/Header.png";
            if (string.IsNullOrEmpty(_path))
            {
                return;
            }
            Document _doc = SetDefaultDocument();
            PdfWriter _write = PdfWriter.GetInstance(_doc, new FileStream(_path, FileMode.Create));
            _doc.Open();

            string _watermake = @"../../Imgs/logo.png";
            Image sw = Image.GetInstance(_watermake);
            sw.GrayFill = 10;
            sw.SetAbsolutePosition(_doc.Right - _doc.Left - 50 - sw.Width, 200);
            _doc.Add(sw);

            //AddWatermake(_doc, _write, Image.GetInstance(_watermake),"测试用例");
            PdfPTable table = new PdfPTable(new float[] { 1, 2, 1, 2, 2 });
            PdfPCell cell;
            cell = new PdfPCell(GetPhrase("发布结果",PDFFONTFAMILY.方正悬针篆变简体,16));
            cell.Padding = 5;
            cell.Colspan = 5;
            //0：left；1：center；2：right；
            cell.HorizontalAlignment =1;
            //0：top；1：center；2：bottom；
            cell.VerticalAlignment = 1;
            table.AddCell(cell);
            table.AddCell(GetPhrase("姓名", PDFFONTFAMILY.宋体,10));
            table.AddCell(GetPhrase("Rain.Wuu", PDFFONTFAMILY.宋体, 10));
            table.AddCell(GetPhrase("性别", PDFFONTFAMILY.宋体, 10));
            table.AddCell(GetPhrase("Man", PDFFONTFAMILY.宋体, 10));
            Image _header = Image.GetInstance(_img);
            
            cell = new PdfPCell(_header);
            cell.Padding = 5;
            cell.Rowspan = 5;
            table.AddCell(cell);
            table.AddCell(GetPhrase("生日", PDFFONTFAMILY.宋体, 10));
            table.AddCell(GetPhrase("2016.10.08", PDFFONTFAMILY.宋体, 10));
            table.AddCell(GetPhrase("身高", PDFFONTFAMILY.宋体, 10));
            table.AddCell(GetPhrase("66 cm", PDFFONTFAMILY.宋体, 10));
            table.AddCell(GetPhrase("籍贯", PDFFONTFAMILY.宋体, 10));
            table.AddCell(GetPhrase("山西省长治市沁县", PDFFONTFAMILY.宋体, 10));
            table.AddCell(GetPhrase("民族", PDFFONTFAMILY.宋体, 10));
            table.AddCell(GetPhrase("汉", PDFFONTFAMILY.宋体, 10));
            table.AddCell(GetPhrase("政治面貌", PDFFONTFAMILY.宋体, 10));
            table.AddCell(GetPhrase("共产党员", PDFFONTFAMILY.宋体, 10));
            table.AddCell(GetPhrase("毕业院校", PDFFONTFAMILY.宋体, 10));
            table.AddCell(GetPhrase("太原理工大学", PDFFONTFAMILY.宋体, 10));
            table.AddCell(GetPhrase("学历", PDFFONTFAMILY.宋体, 10));
            table.AddCell(GetPhrase("本科", PDFFONTFAMILY.宋体, 10));
            table.AddCell(GetPhrase("专业", PDFFONTFAMILY.宋体, 10));
            table.AddCell(GetPhrase("软件设计", PDFFONTFAMILY.宋体, 10));
            cell = new PdfPCell(GetPhrase(_content, PDFFONTFAMILY.宋体, 10));            
            cell.Padding = 5;
            cell.Colspan = 5;
            table.AddCell(cell);
            _doc.Add(table);
            _doc.Close();
        }

        public static void AddWatermark(string inputFile,string outFile,string _path)
        {
            PdfReader _reader = null;
            PdfStamper _stamper = null;
            try
            {
                _reader = new PdfReader(inputFile);
                int pageCount = _reader.NumberOfPages;
                Rectangle pageSize = _reader.GetPageSize(1);
                float _W = pageSize.Width;
                float _H = pageSize.Height;
                _stamper = new PdfStamper(_reader, new FileStream(outFile, FileMode.Create));
                PdfContentByte watermarkContent;
                Image _waterMark = Image.GetInstance(_path);
                //_waterMark.MakeMask();
                _waterMark.GrayFill = 20;
                _waterMark.SetAbsolutePosition(_W / 2 - _waterMark.Width / 2, _H / 2 - _waterMark.Height / 2);
                for (int i = 0; i <= pageCount; i++)
                {
                    watermarkContent = _stamper.GetUnderContent(i);
                    if (watermarkContent == null) continue;
                    watermarkContent.AddImage(_waterMark);
                }
            }
            catch (Exception es)
            {
                System.Windows.MessageBox.Show(es.Message);
            }
            finally
            {
                if (_stamper != null)
                    _stamper.Close();
                if (_reader != null)
                    _reader.Close();
            }
        }

    }
}
