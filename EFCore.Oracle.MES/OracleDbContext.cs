
using EFCore.Oracle.MES.View;
using Microsoft.EntityFrameworkCore;
using System;

namespace EFCore.Oracle.MES
{
    public class OracleDbContext:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder); 
            string connStr = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=QMDB002.qm.cn.conti.de)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=REPORTING.qm.cn.conti.de)));Persist Security Info=True;User ID=mesread;Password=mesread";
            optionsBuilder.UseOracle(connStr, b => b.UseOracleSQLCompatibility("11"));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //视图操作
            modelBuilder.Query<OEEItem>(v =>
            {
                v.ToView("V_OEE_INTERFACE");
                v.Property(p => p.ProductionLine).HasColumnName("RU_NAME");
                v.Property(p => p.OPStation).HasColumnName("RU_NAME");
                v.Property(p => p.OPDate).HasColumnName("SINCE_1970");
                v.Property(p => p.TEEP).HasColumnName("TEEP");
                v.Property(p => p.OEE).HasColumnName("OEE");
                v.Property(p => p.Availability).HasColumnName("AVAILABILITY");
                v.Property(p => p.Performance).HasColumnName("PERFORMANCE");
                v.Property(p => p.QualityRate).HasColumnName("QUALITY_RATE");
            });

            modelBuilder.Query<ProductionLineItem>(v =>
            {
                v.ToView("V_OPSTATION_LINE");
                v.Property(p => p.ProductionLine).HasColumnName("OPSTATION");
                v.Property(p => p.WorkShop).HasColumnName("LINE");
            });

            modelBuilder.Query<OutputItem>(v =>
            {
                v.ToView("V_OUTPUT_INTERFACE");
                v.Property(p => p.Date).HasColumnName("PDATE");
                v.Property(p => p.Name).HasColumnName("RU_NAME");
                v.Property(p => p.Shift).HasColumnName("SHIFT_ID");
                v.Property(p => p.Total_Parts).HasColumnName("TOTAL_PARTS");
                v.Property(p => p.Good_Parts).HasColumnName("GOOD_PARTS");
                v.Property(p => p.Fail_Parts).HasColumnName("FAIL_PARTS");
                v.Property(p => p.Good_Parts_Ratio).HasColumnName("GOOD_PARTS_PERCENT");
                v.Property(p => p.Fail_Parts_Ratio).HasColumnName("FAIL_PARTS_PERCENT");
                v.Property(p => p.Period_Start).HasColumnName("PERIOD_START");
                v.Property(p => p.Period_End).HasColumnName("PERIOD_END");
                v.Property(p => p.PN).HasColumnName("PN");
            });
        }
        //视图操作
        public DbQuery<OEEItem> V_OEE_Interfaces { get; set; }

        public DbQuery<OutputItem> V_Output_Interfaces { get; set; }

    }

    
}
