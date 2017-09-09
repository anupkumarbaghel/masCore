using MAS.Core.Domain.Store.MasterRegister;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MAS.ExcelReport
{
    internal class ConverterMasterRegisterMASMaterialHeader
    {
        private List<MasterLevel3Register> MasterRegToLevel3Reg(List<MasterRegister> registers)
        {
            List<MasterLevel3Register> Level3Register = new List<MasterLevel3Register>();
            foreach (MasterRegister register in registers)
            {
                MasterLevel3Register l3reg = new MasterLevel3Register()
                {
                    SerialNumber = register.SerialNumber
                   , MaterialUnit = register.MaterialUnit
                   , MasterRegisterID = register.ID
                };
                string[] splittedMaterial = register.MaterialNameWithDescription.Split(',');
                foreach (string sepratedMaterial in splittedMaterial)
                {
                    if (string.IsNullOrEmpty(l3reg.Level1))
                        l3reg.Level1 = sepratedMaterial.Trim();
                    else if (string.IsNullOrEmpty(l3reg.Level2))
                        l3reg.Level2 = sepratedMaterial.Trim();
                    else if (string.IsNullOrEmpty(l3reg.Level3))
                        l3reg.Level3 = sepratedMaterial.Trim();
                    else { }
                }
                Level3Register.Add(l3reg);
            }
            return Level3Register;
        }
        private void SetMasterRegisterLevel(MasterLevel3Register Group1stItem, MASMaterialHeader header)
        {
            if (string.IsNullOrEmpty(Group1stItem.Level3))
            {
                if (string.IsNullOrEmpty(Group1stItem.Level2))
                {
                    header.level = 1;
                }
                else
                {
                    header.level = 2;
                }
            }
            else
            {
                header.level = 3;
            }
        }
        public List<MASMaterialHeader> GenerateHeader(List<MasterRegister> registers,List<MAS.Core.DTO.DTOOpeningBalance> openingBalances)
        {
            List<MASMaterialHeader> MASExcelHeaders = new List<MASMaterialHeader>();

            List<MasterLevel3Register> listL3Registers = MasterRegToLevel3Reg(registers);

            var level1Groups = listL3Registers.GroupBy(e => e.Level1);

            foreach (var level1Group in level1Groups)
            {
                MASMaterialHeader header = new MASMaterialHeader();
                header.level1 = new Level1() { MainContent = level1Group.Key };
                MasterLevel3Register Group1stItem = level1Group.First();
                SetMasterRegisterLevel(Group1stItem, header);
                header.Unit = Group1stItem.MaterialUnit;

                if (header.level == 1)
                {
                    decimal openingBal = 0;
                   if(openingBalances.Where(e => e.ID == Group1stItem.MasterRegisterID).FirstOrDefault()!=null)
                        openingBal = openingBalances.Find(e => e.ID == Group1stItem.MasterRegisterID).OpeningBalance;
                    header.level1.leafVallue = new LeafeValue()
                    {
                        Sno = Group1stItem.SerialNumber.ToString()
                    ,
                        MasterRegisterID = Group1stItem.MasterRegisterID
                     , OpeningBalance = openingBal
                    };
                    
                }
                else
                {
                    header.level1.level2s = new List<Level2>();
                    var level2Groups = level1Group.GroupBy(e => e.Level2);
                    foreach (var level2Group in level2Groups)
                    {
                        Level2 lvl2 = new Level2();
                        lvl2.MainContent = level2Group.Key;

                        if (header.level == 2)
                        {
                            decimal openingBal = 0;
                            if (openingBalances.Where(e => e.ID == Group1stItem.MasterRegisterID).FirstOrDefault() != null)
                                openingBal = openingBalances.Find(e => e.ID == Group1stItem.MasterRegisterID).OpeningBalance;
                            lvl2.leafVallue = new LeafeValue() { Sno = level2Group.First().SerialNumber.ToString()
                            ,MasterRegisterID= level2Group.First().MasterRegisterID
                             ,
                                OpeningBalance = openingBal
                            };
                        }
                        else
                        {
                            lvl2.level3s = new List<Level3>();
                            var level3Groups = level2Group.GroupBy(e => e.Level3);
                            foreach (var level3Group in level3Groups)
                            {
                                decimal openingBal = 0;
                                if (openingBalances.Where(e => e.ID == Group1stItem.MasterRegisterID).FirstOrDefault() != null)
                                    openingBal = openingBalances.Find(e => e.ID == Group1stItem.MasterRegisterID).OpeningBalance;

                                Level3 lvl3 = new Level3();
                                lvl3.MainContent = level3Group.Key;
                                lvl3.leafVallue = new LeafeValue() { Sno = level3Group.First().SerialNumber.ToString()
                                ,MasterRegisterID=level3Group.First().MasterRegisterID
                                 ,
                                    OpeningBalance = openingBal
                                };

                                lvl2.level3s.Add(lvl3);
                            }
                        }
                        header.level1.level2s.Add(lvl2);
                    }
                }

                MASExcelHeaders.Add(header);
            }


            return MASExcelHeaders;
        }
    }
}
