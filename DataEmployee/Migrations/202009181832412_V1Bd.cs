namespace DataEmployee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V1Bd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Funcionarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Cpf = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Telefones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumeroTelefone = c.String(),
                        FuncionarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Funcionarios", t => t.FuncionarioId, cascadeDelete: true)
                .Index(t => t.FuncionarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Telefones", "FuncionarioId", "dbo.Funcionarios");
            DropIndex("dbo.Telefones", new[] { "FuncionarioId" });
            DropTable("dbo.Telefones");
            DropTable("dbo.Funcionarios");
        }
    }
}
