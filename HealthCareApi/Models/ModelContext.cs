using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HealthCareApi.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<HeaAgents> HeaAgents { get; set; }
        public virtual DbSet<HeaAnswers> HeaAnswers { get; set; }
        public virtual DbSet<HeaBenefits> HeaBenefits { get; set; }
        public virtual DbSet<HeaBranches> HeaBranches { get; set; }
        public virtual DbSet<HeaClients> HeaClients { get; set; }
        public virtual DbSet<HeaCorporateInfo> HeaCorporateInfo { get; set; }
        public virtual DbSet<HeaDocs> HeaDocs { get; set; }
        public virtual DbSet<HeaInsuredPersons> HeaInsuredPersons { get; set; }
        public virtual DbSet<HeaOptionalBenefits> HeaOptionalBenefits { get; set; }
        public virtual DbSet<HeaPersonalInfo> HeaPersonalInfo { get; set; }
        public virtual DbSet<HeaPlanDetails> HeaPlanDetails { get; set; }
        public virtual DbSet<HeaPlans> HeaPlans { get; set; }
        public virtual DbSet<HeaPolicyHeader> HeaPolicyHeader { get; set; }
        public virtual DbSet<HeaPolicyNo> HeaPolicyNo { get; set; }
        public virtual DbSet<HeaPrices> HeaPrices { get; set; }
        public virtual DbSet<HeaProducts> HeaProducts { get; set; }
        public virtual DbSet<HeaQuestions> HeaQuestions { get; set; }
        public virtual DbSet<HeaSettings> HeaSettings { get; set; }
        public virtual DbSet<HeaTrans> HeaTrans { get; set; }
        public virtual DbSet<HeaTreatments> HeaTreatments { get; set; }
        public virtual DbSet<HeaUsers> HeaUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseOracle("User Id=msig;Password=Hanoi2020$;Data Source=localhost:1521/xe;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "MSIG");

            modelBuilder.Entity<HeaAgents>(entity =>
            {
                entity.ToTable("HEA_AGENTS");

                entity.HasIndex(e => e.Id)
                    .HasName("PK_AGENTS")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AgentCode)
                    .HasColumnName("AGENT_CODE")
                    .HasColumnType("VARCHAR2(10)");

                entity.Property(e => e.AgentName)
                    .HasColumnName("AGENT_NAME")
                    .HasColumnType("VARCHAR2(250)");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasColumnType("VARCHAR2(30)");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnName("UPDATED_DATE")
                    .HasColumnType("DATE");
            });

            modelBuilder.Entity<HeaAnswers>(entity =>
            {
                entity.ToTable("HEA_ANSWERS");

                entity.HasIndex(e => e.Id)
                    .HasName("HEA_ANSWERS_ID_PK")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Answer)
                    .HasColumnName("ANSWER")
                    .HasColumnType("VARCHAR2(1)");

                entity.Property(e => e.PolicyRiskId).HasColumnName("POLICY_RISK_ID");

                entity.Property(e => e.QuestionId).HasColumnName("QUESTION_ID");

                entity.HasOne(d => d.PolicyRisk)
                    .WithMany(p => p.HeaAnswers)
                    .HasForeignKey(d => d.PolicyRiskId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("HEA_ANSWERS_POLICY_RISK_FK");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.HeaAnswers)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("HEA_ANSWERS_QUESTION_ID_FK");
            });

            modelBuilder.Entity<HeaBenefits>(entity =>
            {
                entity.ToTable("HEA_BENEFITS");

                entity.HasIndex(e => e.Id)
                    .HasName("PK_BENEFITS")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BenefitCode)
                    .HasColumnName("BENEFIT_CODE")
                    .HasColumnType("VARCHAR2(5)");

                entity.Property(e => e.BenefitName)
                    .HasColumnName("BENEFIT_NAME")
                    .HasColumnType("VARCHAR2(250)");

                entity.Property(e => e.Flag)
                    .HasColumnName("FLAG")
                    .HasColumnType("VARCHAR2(1)");

                entity.Property(e => e.ProductId).HasColumnName("PRODUCT_ID");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasColumnType("VARCHAR2(30)");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnName("UPDATED_DATE")
                    .HasColumnType("DATE");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.HeaBenefits)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_BENEFITS_PRODUCTS");
            });

            modelBuilder.Entity<HeaBranches>(entity =>
            {
                entity.ToTable("HEA_BRANCHES");

                entity.HasIndex(e => e.Id)
                    .HasName("PK_BRANCHES")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BranchCode)
                    .HasColumnName("BRANCH_CODE")
                    .HasColumnType("VARCHAR2(10)");

                entity.Property(e => e.BranchId).HasColumnName("BRANCH_ID");

                entity.Property(e => e.BranchName)
                    .HasColumnName("BRANCH_NAME")
                    .HasColumnType("VARCHAR2(255)");

                entity.Property(e => e.PartnerId).HasColumnName("PARTNER_ID");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasColumnType("VARCHAR2(30)");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnName("UPDATED_DATE")
                    .HasColumnType("DATE");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.InverseBranch)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK_BRANCHES_BRANCHES");
            });

            modelBuilder.Entity<HeaClients>(entity =>
            {
                entity.ToTable("HEA_CLIENTS");

                entity.HasIndex(e => e.Id)
                    .HasName("PK_CLIENT_INFO")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasColumnType("VARCHAR2(500)");

                entity.Property(e => e.ClientName)
                    .HasColumnName("CLIENT_NAME")
                    .HasColumnType("VARCHAR2(250)");

                entity.Property(e => e.ClientType)
                    .HasColumnName("CLIENT_TYPE")
                    .HasColumnType("VARCHAR2(1)");

                entity.Property(e => e.Contact)
                    .HasColumnName("CONTACT")
                    .HasColumnType("VARCHAR2(255)");

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasColumnType("VARCHAR2(50)");

                entity.Property(e => e.IdentityNo)
                    .HasColumnName("IDENTITY_NO")
                    .HasColumnType("VARCHAR2(16)");

                entity.Property(e => e.IdentityType)
                    .HasColumnName("IDENTITY_TYPE")
                    .HasColumnType("VARCHAR2(1)");

                entity.Property(e => e.Mobile)
                    .HasColumnName("MOBILE")
                    .HasColumnType("VARCHAR2(16)");

                entity.Property(e => e.Nationality)
                    .HasColumnName("NATIONALITY")
                    .HasColumnType("VARCHAR2(3)");

                entity.Property(e => e.OffPhone)
                    .HasColumnName("OFF_PHONE")
                    .HasColumnType("VARCHAR2(16)");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasColumnType("VARCHAR2(30)");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnName("UPDATED_DATE")
                    .HasColumnType("DATE");
            });

            modelBuilder.Entity<HeaCorporateInfo>(entity =>
            {
                entity.ToTable("HEA_CORPORATE_INFO");

                entity.HasIndex(e => e.Id)
                    .HasName("PK_CORPORATE_INFO")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClientInfoId).HasColumnName("CLIENT_INFO_ID");

                entity.Property(e => e.CountryOrigin)
                    .HasColumnName("COUNTRY_ORIGIN")
                    .HasColumnType("VARCHAR2(30)");

                entity.Property(e => e.TaxNum)
                    .HasColumnName("TAX_NUM")
                    .HasColumnType("VARCHAR2(255)");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasColumnType("VARCHAR2(30)");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnName("UPDATED_DATE")
                    .HasColumnType("DATE");

                entity.HasOne(d => d.ClientInfo)
                    .WithMany(p => p.HeaCorporateInfo)
                    .HasForeignKey(d => d.ClientInfoId)
                    .HasConstraintName("FK_CORPORATE_INFO_CLIENT");
            });

            modelBuilder.Entity<HeaDocs>(entity =>
            {
                entity.ToTable("HEA_DOCS");

                entity.HasIndex(e => e.Id)
                    .HasName("PK_HEA_DOC")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DocType)
                    .HasColumnName("DOC_TYPE")
                    .HasColumnType("NUMBER(2)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.FileContent)
                    .HasColumnName("FILE_CONTENT")
                    .HasColumnType("BLOB");

                entity.Property(e => e.FileName)
                    .HasColumnName("FILE_NAME")
                    .HasColumnType("VARCHAR2(255)")
                    .HasDefaultValueSql("'document.pdf'");

                entity.Property(e => e.FileType)
                    .HasColumnName("FILE_TYPE")
                    .HasColumnType("VARCHAR2(5)")
                    .HasDefaultValueSql("'pdf'");

                entity.Property(e => e.PolicyHeaderId).HasColumnName("POLICY_HEADER_ID");

                entity.Property(e => e.PolicyNo)
                    .HasColumnName("POLICY_NO")
                    .HasColumnType("VARCHAR2(10)");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasColumnType("VARCHAR2(30)");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnName("UPDATED_DATE")
                    .HasColumnType("DATE");

                entity.HasOne(d => d.PolicyHeader)
                    .WithMany(p => p.HeaDocs)
                    .HasForeignKey(d => d.PolicyHeaderId)
                    .HasConstraintName("FK_HEA_DOC_POLICY_HEADER");
            });

            modelBuilder.Entity<HeaInsuredPersons>(entity =>
            {
                entity.ToTable("HEA_INSURED_PERSONS");

                entity.HasIndex(e => e.Id)
                    .HasName("PK_POLICY_RISKS")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Age).HasColumnName("AGE");

                entity.Property(e => e.ClientInfoId).HasColumnName("CLIENT_INFO_ID");

                entity.Property(e => e.Gender)
                    .HasColumnName("GENDER")
                    .HasColumnType("VARCHAR2(1)");

                entity.Property(e => e.OptPreAmt)
                    .HasColumnName("OPT_PRE_AMT")
                    .HasColumnType("NUMBER(18)");

                entity.Property(e => e.PlanId).HasColumnName("PLAN_ID");

                entity.Property(e => e.PolicyHeaderId).HasColumnName("POLICY_HEADER_ID");

                entity.Property(e => e.PreAmt)
                    .HasColumnName("PRE_AMT")
                    .HasColumnType("NUMBER(18)");

                entity.Property(e => e.RelativeType)
                    .HasColumnName("RELATIVE_TYPE")
                    .HasColumnType("VARCHAR2(5)");

                entity.Property(e => e.Si)
                    .HasColumnName("SI")
                    .HasColumnType("NUMBER(18)");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasColumnType("VARCHAR2(30)");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnName("UPDATED_DATE")
                    .HasColumnType("DATE");

                entity.HasOne(d => d.ClientInfo)
                    .WithMany(p => p.HeaInsuredPersons)
                    .HasForeignKey(d => d.ClientInfoId)
                    .HasConstraintName("FK_POLICY_RISK_CLIENT_INFO");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.HeaInsuredPersons)
                    .HasForeignKey(d => d.PlanId)
                    .HasConstraintName("FK_POLICY_RISKS_PLAN");

                entity.HasOne(d => d.PolicyHeader)
                    .WithMany(p => p.HeaInsuredPersons)
                    .HasForeignKey(d => d.PolicyHeaderId)
                    .HasConstraintName("FK_POLICY_RISKS_HEADER");
            });

            modelBuilder.Entity<HeaOptionalBenefits>(entity =>
            {
                entity.ToTable("HEA_OPTIONAL_BENEFITS");

                entity.HasIndex(e => e.Id)
                    .HasName("PK_RISK_DETAILS")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BenefitCode)
                    .HasColumnName("BENEFIT_CODE")
                    .HasColumnType("VARCHAR2(5)");

                entity.Property(e => e.BenefitId).HasColumnName("BENEFIT_ID");

                entity.Property(e => e.OptionalFlag)
                    .HasColumnName("OPTIONAL_FLAG")
                    .HasColumnType("VARCHAR2(1)");

                entity.Property(e => e.PolicyRiskId).HasColumnName("POLICY_RISK_ID");

                entity.Property(e => e.PreAmt)
                    .HasColumnName("PRE_AMT")
                    .HasColumnType("NUMBER(18)");

                entity.Property(e => e.Si)
                    .HasColumnName("SI")
                    .HasColumnType("NUMBER(18)");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasColumnType("VARCHAR2(30)");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnName("UPDATED_DATE")
                    .HasColumnType("DATE");

                entity.HasOne(d => d.Benefit)
                    .WithMany(p => p.HeaOptionalBenefits)
                    .HasForeignKey(d => d.BenefitId)
                    .HasConstraintName("FK_RISK_DETAILS_BENEFIT");

                entity.HasOne(d => d.PolicyRisk)
                    .WithMany(p => p.HeaOptionalBenefits)
                    .HasForeignKey(d => d.PolicyRiskId)
                    .HasConstraintName("FK_RISK_DETAILS_RISK");
            });

            modelBuilder.Entity<HeaPersonalInfo>(entity =>
            {
                entity.ToTable("HEA_PERSONAL_INFO");

                entity.HasIndex(e => e.Id)
                    .HasName("PK_PERSONAL_INFO")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClientInfoId).HasColumnName("CLIENT_INFO_ID");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("DATE");

                entity.Property(e => e.Gender)
                    .HasColumnName("GENDER")
                    .HasColumnType("VARCHAR2(1)");

                entity.Property(e => e.Married)
                    .HasColumnName("MARRIED")
                    .HasColumnType("VARCHAR2(1)");

                entity.Property(e => e.Occupation)
                    .HasColumnName("OCCUPATION")
                    .HasColumnType("VARCHAR2(50)");

                entity.Property(e => e.Position)
                    .HasColumnName("POSITION")
                    .HasColumnType("VARCHAR2(250)");

                entity.Property(e => e.Salutation)
                    .HasColumnName("SALUTATION")
                    .HasColumnType("VARCHAR2(8)");

                entity.HasOne(d => d.ClientInfo)
                    .WithMany(p => p.HeaPersonalInfo)
                    .HasForeignKey(d => d.ClientInfoId)
                    .HasConstraintName("FK_PERSONAL_INFO");
            });

            modelBuilder.Entity<HeaPlanDetails>(entity =>
            {
                entity.ToTable("HEA_PLAN_DETAILS");

                entity.HasIndex(e => e.Id)
                    .HasName("PK_PLAN_DETAILS")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BenefitId).HasColumnName("BENEFIT_ID");

                entity.Property(e => e.PlanId).HasColumnName("PLAN_ID");

                entity.Property(e => e.Si)
                    .HasColumnName("SI")
                    .HasColumnType("NUMBER(18)");

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasColumnType("VARCHAR2(250)");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasColumnType("VARCHAR2(30)");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnName("UPDATED_DATE")
                    .HasColumnType("DATE");

                entity.HasOne(d => d.Benefit)
                    .WithMany(p => p.HeaPlanDetails)
                    .HasForeignKey(d => d.BenefitId)
                    .HasConstraintName("FK_PLAN_DETAIL_BENEFIT");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.HeaPlanDetails)
                    .HasForeignKey(d => d.PlanId)
                    .HasConstraintName("FK_PLAN_DETAIL_PLAN");
            });

            modelBuilder.Entity<HeaPlans>(entity =>
            {
                entity.ToTable("HEA_PLANS");

                entity.HasIndex(e => e.Id)
                    .HasName("PK_HEA_PLANS")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PlanCode)
                    .HasColumnName("PLAN_CODE")
                    .HasColumnType("VARCHAR2(10)");

                entity.Property(e => e.PlanName)
                    .HasColumnName("PLAN_NAME")
                    .HasColumnType("VARCHAR2(250)");

                entity.Property(e => e.ProductId).HasColumnName("PRODUCT_ID");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasColumnType("VARCHAR2(30)");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnName("UPDATED_DATE")
                    .HasColumnType("DATE");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.HeaPlans)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_PLANS_PRODUCTS");
            });

            modelBuilder.Entity<HeaPolicyHeader>(entity =>
            {
                entity.ToTable("HEA_POLICY_HEADER");

                entity.HasIndex(e => e.Id)
                    .HasName("PK_POLICY_HEADER")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AgentId).HasColumnName("AGENT_ID");

                entity.Property(e => e.BranchId).HasColumnName("BRANCH_ID");

                entity.Property(e => e.ClientInfoId).HasColumnName("CLIENT_INFO_ID");

                entity.Property(e => e.Discount)
                    .HasColumnName("DISCOUNT")
                    .HasColumnType("NUMBER(18)");

                entity.Property(e => e.ExpireDate)
                    .HasColumnName("EXPIRE_DATE")
                    .HasColumnType("DATE");

                entity.Property(e => e.InceptionDate)
                    .HasColumnName("INCEPTION_DATE")
                    .HasColumnType("DATE");

                entity.Property(e => e.LastStatus)
                    .HasColumnName("LAST_STATUS")
                    .HasColumnType("NUMBER(2)");

                entity.Property(e => e.Netpre)
                    .HasColumnName("NETPRE")
                    .HasColumnType("NUMBER(18)");

                entity.Property(e => e.PolicyHeaderId).HasColumnName("POLICY_HEADER_ID");

                entity.Property(e => e.PolicyNo)
                    .HasColumnName("POLICY_NO")
                    .HasColumnType("VARCHAR2(10)");

                entity.Property(e => e.StaffId).HasColumnName("STAFF_ID");

                entity.Property(e => e.TotalSi)
                    .HasColumnName("TOTAL_SI")
                    .HasColumnType("NUMBER(18)");

                entity.Property(e => e.Totalpre)
                    .HasColumnName("TOTALPRE")
                    .HasColumnType("NUMBER(18)");

                entity.Property(e => e.TranDate)
                    .HasColumnName("TRAN_DATE")
                    .HasColumnType("DATE");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasColumnType("VARCHAR2(30)");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnName("UPDATED_DATE")
                    .HasColumnType("DATE");

                entity.HasOne(d => d.Agent)
                    .WithMany(p => p.HeaPolicyHeader)
                    .HasForeignKey(d => d.AgentId)
                    .HasConstraintName("FK_POLICY_HEADER_AGENT");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.HeaPolicyHeader)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK_POLICY_HEADER_BRANCH");

                entity.HasOne(d => d.ClientInfo)
                    .WithMany(p => p.HeaPolicyHeader)
                    .HasForeignKey(d => d.ClientInfoId)
                    .HasConstraintName("FK_POLICY_HEADER_CLIENT_INFO");
            });

            modelBuilder.Entity<HeaPolicyNo>(entity =>
            {
                entity.HasKey(e => e.PolicyNo);

                entity.ToTable("HEA_POLICY_NO");

                entity.HasIndex(e => e.PolicyNo)
                    .HasName("PK_POLICY_NO")
                    .IsUnique();

                entity.Property(e => e.PolicyNo).HasColumnName("POLICY_NO");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasColumnType("VARCHAR2(30)");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnName("UPDATED_DATE")
                    .HasColumnType("DATE");
            });

            modelBuilder.Entity<HeaPrices>(entity =>
            {
                entity.ToTable("HEA_PRICES");

                entity.HasIndex(e => e.Id)
                    .HasName("PK_PRICES")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BenefitId).HasColumnName("BENEFIT_ID");

                entity.Property(e => e.FromAge).HasColumnName("FROM_AGE");

                entity.Property(e => e.PlanId).HasColumnName("PLAN_ID");

                entity.Property(e => e.Price)
                    .HasColumnName("PRICE")
                    .HasColumnType("NUMBER(18)");

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasColumnType("VARCHAR2(250)");

                entity.Property(e => e.ToAge).HasColumnName("TO_AGE");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasColumnType("VARCHAR2(30)");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnName("UPDATED_DATE")
                    .HasColumnType("DATE");

                entity.HasOne(d => d.Benefit)
                    .WithMany(p => p.HeaPrices)
                    .HasForeignKey(d => d.BenefitId)
                    .HasConstraintName("FK_PRICE_BENEFIT");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.HeaPrices)
                    .HasForeignKey(d => d.PlanId)
                    .HasConstraintName("FK_PRICE_PLAN");
            });

            modelBuilder.Entity<HeaProducts>(entity =>
            {
                entity.ToTable("HEA_PRODUCTS");

                entity.HasIndex(e => e.Id)
                    .HasName("PK_PRODUCTS")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ProdCode)
                    .HasColumnName("PROD_CODE")
                    .HasColumnType("VARCHAR2(10)");

                entity.Property(e => e.ProdName)
                    .HasColumnName("PROD_NAME")
                    .HasColumnType("VARCHAR2(250)");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasColumnType("VARCHAR2(30)");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnName("UPDATED_DATE")
                    .HasColumnType("DATE");
            });

            modelBuilder.Entity<HeaQuestions>(entity =>
            {
                entity.ToTable("HEA_QUESTIONS");

                entity.HasIndex(e => e.Id)
                    .HasName("HEA_QUESTIONS_ID_PK")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Question)
                    .HasColumnName("QUESTION")
                    .HasColumnType("VARCHAR2(1000)");

                entity.Property(e => e.TheOrder)
                    .HasColumnName("THE_ORDER")
                    .HasColumnType("NUMBER(2)");
            });

            modelBuilder.Entity<HeaSettings>(entity =>
            {
                entity.ToTable("HEA_SETTINGS");

                entity.HasIndex(e => e.Id)
                    .HasName("PK_HEA_SETTINGS")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ItemKey)
                    .HasColumnName("ITEM_KEY")
                    .HasColumnType("VARCHAR2(30)");

                entity.Property(e => e.ItemTable)
                    .HasColumnName("ITEM_TABLE")
                    .HasColumnType("VARCHAR2(5)");

                entity.Property(e => e.ItemValue)
                    .HasColumnName("ITEM_VALUE")
                    .HasColumnType("VARCHAR2(1000)");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasColumnType("VARCHAR2(30)");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnName("UPDATED_DATE")
                    .HasColumnType("DATE");
            });

            modelBuilder.Entity<HeaTrans>(entity =>
            {
                entity.ToTable("HEA_TRANS");

                entity.HasIndex(e => e.Id)
                    .HasName("HEA_TRANSACTIONS_ID_PK")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PolicyHeaderId).HasColumnName("POLICY_HEADER_ID");

                entity.Property(e => e.ReqTranNo)
                    .HasColumnName("REQ_TRAN_NO")
                    .HasColumnType("VARCHAR2(32)");

                entity.Property(e => e.ResTranNo)
                    .HasColumnName("RES_TRAN_NO")
                    .HasColumnType("VARCHAR2(32)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasColumnType("NUMBER(2)");

                entity.Property(e => e.TranDate)
                    .HasColumnName("TRAN_DATE")
                    .HasColumnType("DATE");

                entity.HasOne(d => d.PolicyHeader)
                    .WithMany(p => p.HeaTrans)
                    .HasForeignKey(d => d.PolicyHeaderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("HEA_TRANSACTI_POLICY_HEADER_FK");
            });

            modelBuilder.Entity<HeaTreatments>(entity =>
            {
                entity.ToTable("HEA_TREATMENTS");

                entity.HasIndex(e => e.Id)
                    .HasName("HEA_RESULTS_ID_PK")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Disease)
                    .HasColumnName("DISEASE")
                    .HasColumnType("VARCHAR2(1000)");

                entity.Property(e => e.Examination)
                    .HasColumnName("EXAMINATION")
                    .HasColumnType("VARCHAR2(1000)");

                entity.Property(e => e.PolicyRiskId).HasColumnName("POLICY_RISK_ID");

                entity.Property(e => e.Treatment)
                    .HasColumnName("TREATMENT")
                    .HasColumnType("VARCHAR2(1000)");

                entity.HasOne(d => d.PolicyRisk)
                    .WithMany(p => p.HeaTreatments)
                    .HasForeignKey(d => d.PolicyRiskId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("HEA_RESULTS_POLICY_RISK_FK");
            });

            modelBuilder.Entity<HeaUsers>(entity =>
            {
                entity.ToTable("HEA_USERS");

                entity.HasIndex(e => e.Id)
                    .HasName("PK_STAFF")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BranchId).HasColumnName("BRANCH_ID");

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasColumnType("VARCHAR2(255)");

                entity.Property(e => e.FullName)
                    .HasColumnName("FULL_NAME")
                    .HasColumnType("VARCHAR2(255)");

                entity.Property(e => e.Telephone)
                    .HasColumnName("TELEPHONE")
                    .HasColumnType("VARCHAR2(30)");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasColumnType("VARCHAR2(30)");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnName("UPDATED_DATE")
                    .HasColumnType("DATE");

                entity.Property(e => e.UserName)
                    .HasColumnName("USER_NAME")
                    .HasColumnType("VARCHAR2(30)");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.HeaUsers)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK_STAFF_BRANCH");
            });

            modelBuilder.HasSequence("SQ_HEA_AGENTS");

            modelBuilder.HasSequence("SQ_HEA_ANSWERS");

            modelBuilder.HasSequence("SQ_HEA_BENEFITS");

            modelBuilder.HasSequence("SQ_HEA_BRANCHES");

            modelBuilder.HasSequence("SQ_HEA_CLIENT_INFO");

            modelBuilder.HasSequence("SQ_HEA_COMPANY_TRANNO");

            modelBuilder.HasSequence("SQ_HEA_CORPORATE_INFO");

            modelBuilder.HasSequence("SQ_HEA_DISEASES");

            modelBuilder.HasSequence("SQ_HEA_DOCS");

            modelBuilder.HasSequence("SQ_HEA_INSURED_DETAILS");

            modelBuilder.HasSequence("SQ_HEA_PARTNER");

            modelBuilder.HasSequence("SQ_HEA_PERSONAL_INFO");

            modelBuilder.HasSequence("SQ_HEA_PLAN_DETAILS");

            modelBuilder.HasSequence("SQ_HEA_PLANS");

            modelBuilder.HasSequence("SQ_HEA_POLICY_HEADER");

            modelBuilder.HasSequence("SQ_HEA_POLICY_NO");

            modelBuilder.HasSequence("SQ_HEA_POLICY_RISKS");

            modelBuilder.HasSequence("SQ_HEA_PRICES");

            modelBuilder.HasSequence("SQ_HEA_PRODUCTS");

            modelBuilder.HasSequence("SQ_HEA_QUESTION");

            modelBuilder.HasSequence("SQ_HEA_RESULTS");

            modelBuilder.HasSequence("SQ_HEA_RISK_DETAILS");

            modelBuilder.HasSequence("SQ_HEA_SETTINGS");

            modelBuilder.HasSequence("SQ_HEA_STAFF");

            modelBuilder.HasSequence("SQ_HEA_TRANSACTIONS");
        }
    }
}
