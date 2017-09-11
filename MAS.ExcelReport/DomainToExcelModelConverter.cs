using MAS.Core.Domain.Store.Indent;
using MAS.Core.Domain.Store.MeasurementBook;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MAS.ExcelReport
{
    internal class DomainToExcelModelConverter
    {
        public List<IndentMBExcelReportModel> ReceivedExcelReportItem { get;private set; }
        public List<IndentMBExcelReportModel> IssuedExcelReportItem { get;private set; }


        
        public DomainToExcelModelConverter(IEnumerable<Indent> indentList, IEnumerable<MeasurementBook> mblist)
        {
            ReceivedExcelReportItem = new List<IndentMBExcelReportModel>();
            IssuedExcelReportItem = new List<IndentMBExcelReportModel>();
            ConvertIndentToExcelModel(indentList);
            ConvertMBToExcelModel(mblist);
            OrderOutput();
        }

        public void ConvertIndentToExcelModel(IEnumerable<Indent> indentList)
        {
            foreach (Indent indent in indentList)
            {
                IndentMBExcelReportModel model = new IndentMBExcelReportModel();
                model.DateOfReciept = Convert.ToDateTime(indent.SubmittedDate);
                model.IndentNoNDate = indent.IndentNumber + " / " + indent.IndentDate.ToDate();
                model.ReceivedIssue = indent.IsReceive ? indent.ProvidedBy : indent.ProvidedTo;
                model.HeadOfAccount = indent.HeadOfAccount;
                model.IndentMBMaterials = new List<IndentMBMaterialExcelReport>();
                foreach (IndentTable indentMaterial in indent.IndentTableCollection)
                {
                    IndentMBMaterialExcelReport material = new IndentMBMaterialExcelReport();
                    material.MasterRegisterID = indentMaterial.MasterRegister.ID;
                    material.Quantity = indentMaterial.Quantity;
                    model.IndentMBMaterials.Add(material);
                }
                if (indent.IsReceive)
                {
                    ReceivedExcelReportItem.Add(model);
                }
                else
                {
                    IssuedExcelReportItem.Add(model);
                }
            }

        }

        public void ConvertMBToExcelModel(IEnumerable<MeasurementBook> mblist)
        {
            foreach (MeasurementBook mb in mblist)
            {
                IndentMBExcelReportModel model = new IndentMBExcelReportModel();
                model.DateOfReciept = Convert.ToDateTime(mb.MeasurementDate);
                model.IndentNoNDate = string.Empty;

                model.ReceivedIssue = GetReceivedIssueMB(mb);


                model.HeadOfAccount = mb.HeadOfAccount;
                model.IndentMBMaterials = new List<IndentMBMaterialExcelReport>();
                foreach (MeasurementBookTable mbMaterial in mb.MBTable)
                {
                    IndentMBMaterialExcelReport material = new IndentMBMaterialExcelReport();
                    material.MasterRegisterID = mbMaterial.MasterRegister.ID;
                    material.Quantity = mbMaterial.Quantity;
                    model.IndentMBMaterials.Add(material);
                }

                ReceivedExcelReportItem.Add(model);
            }
        }
        private string GetReceivedIssueMB(MeasurementBook mb)
        {
            string result;
            result = mb.NameOfContractor;
            if (!string.IsNullOrEmpty(mb.MBNumber))
                result = result + ", MB " + mb.MBNumber;
            if (!string.IsNullOrEmpty(mb.LUNOrderNo))
                result = result + ", LUN NO " + mb.LUNOrderNo;
            if (!string.IsNullOrEmpty(mb.PageNumber))
                result = result + ", Page " + mb.PageNumber;
            if (!string.IsNullOrEmpty(mb.AggrementNumber))
                result = result + ", Ag " + mb.AggrementNumber;
            if (!string.IsNullOrEmpty(mb.WorkOrderNumber))
                result = result + ", W.O " + mb.WorkOrderNumber;

            return result;
        }
        public void OrderOutput()
        {
            ReceivedExcelReportItem = ReceivedExcelReportItem.OrderBy(e => e.DateOfReciept).ToList();
            IssuedExcelReportItem = IssuedExcelReportItem.OrderBy(e => e.DateOfReciept).ToList();
        }
    }
}
