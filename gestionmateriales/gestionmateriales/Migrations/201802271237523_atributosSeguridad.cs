namespace gestionmateriales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atributosSeguridad : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Entrada", "CREATED_BY", c => c.String(nullable: false, unicode: false));
            AddColumn("dbo.Entrada", "CREATION_DATE", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AddColumn("dbo.Entrada", "CREATION_IP", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AddColumn("dbo.Entrada", "LAST_UPDATED_BY", c => c.String(nullable: false, unicode: false));
            AddColumn("dbo.Entrada", "LAST_UPDATED_DATE", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AddColumn("dbo.Entrada", "LAST_UPDATED_IP", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AddColumn("dbo.Material", "CREATED_BY", c => c.String(nullable: false, unicode: false));
            AddColumn("dbo.Material", "CREATION_DATE", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AddColumn("dbo.Material", "CREATION_IP", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AddColumn("dbo.Material", "LAST_UPDATED_BY", c => c.String(nullable: false, unicode: false));
            AddColumn("dbo.Material", "LAST_UPDATED_DATE", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AddColumn("dbo.Material", "LAST_UPDATED_IP", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AddColumn("dbo.Proveedor", "CREATED_BY", c => c.String(nullable: false, unicode: false));
            AddColumn("dbo.Proveedor", "CREATION_DATE", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AddColumn("dbo.Proveedor", "CREATION_IP", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AddColumn("dbo.Proveedor", "LAST_UPDATED_BY", c => c.String(nullable: false, unicode: false));
            AddColumn("dbo.Proveedor", "LAST_UPDATED_DATE", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AddColumn("dbo.Proveedor", "LAST_UPDATED_IP", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AddColumn("dbo.Salida", "CREATED_BY", c => c.String(nullable: false, unicode: false));
            AddColumn("dbo.Salida", "CREATION_DATE", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AddColumn("dbo.Salida", "CREATION_IP", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AddColumn("dbo.Salida", "LAST_UPDATED_BY", c => c.String(nullable: false, unicode: false));
            AddColumn("dbo.Salida", "LAST_UPDATED_DATE", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AddColumn("dbo.Salida", "LAST_UPDATED_IP", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AddColumn("dbo.Personal", "CREATED_BY", c => c.String(nullable: false, unicode: false));
            AddColumn("dbo.Personal", "CREATION_DATE", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AddColumn("dbo.Personal", "CREATION_IP", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AddColumn("dbo.Personal", "LAST_UPDATED_BY", c => c.String(nullable: false, unicode: false));
            AddColumn("dbo.Personal", "LAST_UPDATED_DATE", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AddColumn("dbo.Personal", "LAST_UPDATED_IP", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AddColumn("dbo.OrdenPedido", "CREATED_BY", c => c.String(nullable: false, unicode: false));
            AddColumn("dbo.OrdenPedido", "CREATION_DATE", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AddColumn("dbo.OrdenPedido", "CREATION_IP", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AddColumn("dbo.OrdenPedido", "LAST_UPDATED_BY", c => c.String(nullable: false, unicode: false));
            AddColumn("dbo.OrdenPedido", "LAST_UPDATED_DATE", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AddColumn("dbo.OrdenPedido", "LAST_UPDATED_IP", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AddColumn("dbo.OrdenTrabajo", "CREATED_BY", c => c.String(nullable: false, unicode: false));
            AddColumn("dbo.OrdenTrabajo", "CREATION_DATE", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AddColumn("dbo.OrdenTrabajo", "CREATION_IP", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AddColumn("dbo.OrdenTrabajo", "LAST_UPDATED_BY", c => c.String(nullable: false, unicode: false));
            AddColumn("dbo.OrdenTrabajo", "LAST_UPDATED_DATE", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AddColumn("dbo.OrdenTrabajo", "LAST_UPDATED_IP", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrdenTrabajo", "LAST_UPDATED_IP");
            DropColumn("dbo.OrdenTrabajo", "LAST_UPDATED_DATE");
            DropColumn("dbo.OrdenTrabajo", "LAST_UPDATED_BY");
            DropColumn("dbo.OrdenTrabajo", "CREATION_IP");
            DropColumn("dbo.OrdenTrabajo", "CREATION_DATE");
            DropColumn("dbo.OrdenTrabajo", "CREATED_BY");
            DropColumn("dbo.OrdenPedido", "LAST_UPDATED_IP");
            DropColumn("dbo.OrdenPedido", "LAST_UPDATED_DATE");
            DropColumn("dbo.OrdenPedido", "LAST_UPDATED_BY");
            DropColumn("dbo.OrdenPedido", "CREATION_IP");
            DropColumn("dbo.OrdenPedido", "CREATION_DATE");
            DropColumn("dbo.OrdenPedido", "CREATED_BY");
            DropColumn("dbo.Personal", "LAST_UPDATED_IP");
            DropColumn("dbo.Personal", "LAST_UPDATED_DATE");
            DropColumn("dbo.Personal", "LAST_UPDATED_BY");
            DropColumn("dbo.Personal", "CREATION_IP");
            DropColumn("dbo.Personal", "CREATION_DATE");
            DropColumn("dbo.Personal", "CREATED_BY");
            DropColumn("dbo.Salida", "LAST_UPDATED_IP");
            DropColumn("dbo.Salida", "LAST_UPDATED_DATE");
            DropColumn("dbo.Salida", "LAST_UPDATED_BY");
            DropColumn("dbo.Salida", "CREATION_IP");
            DropColumn("dbo.Salida", "CREATION_DATE");
            DropColumn("dbo.Salida", "CREATED_BY");
            DropColumn("dbo.Proveedor", "LAST_UPDATED_IP");
            DropColumn("dbo.Proveedor", "LAST_UPDATED_DATE");
            DropColumn("dbo.Proveedor", "LAST_UPDATED_BY");
            DropColumn("dbo.Proveedor", "CREATION_IP");
            DropColumn("dbo.Proveedor", "CREATION_DATE");
            DropColumn("dbo.Proveedor", "CREATED_BY");
            DropColumn("dbo.Material", "LAST_UPDATED_IP");
            DropColumn("dbo.Material", "LAST_UPDATED_DATE");
            DropColumn("dbo.Material", "LAST_UPDATED_BY");
            DropColumn("dbo.Material", "CREATION_IP");
            DropColumn("dbo.Material", "CREATION_DATE");
            DropColumn("dbo.Material", "CREATED_BY");
            DropColumn("dbo.Entrada", "LAST_UPDATED_IP");
            DropColumn("dbo.Entrada", "LAST_UPDATED_DATE");
            DropColumn("dbo.Entrada", "LAST_UPDATED_BY");
            DropColumn("dbo.Entrada", "CREATION_IP");
            DropColumn("dbo.Entrada", "CREATION_DATE");
            DropColumn("dbo.Entrada", "CREATED_BY");
        }
    }
}
