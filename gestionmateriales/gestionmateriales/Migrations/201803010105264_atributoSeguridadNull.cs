namespace gestionmateriales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atributoSeguridadNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Entrada", "CREATED_BY", c => c.String(maxLength: 50, storeType: "nvarchar"));
            AlterColumn("dbo.Entrada", "CREATION_DATE", c => c.String(maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.Entrada", "CREATION_IP", c => c.String(maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.Entrada", "LAST_UPDATED_BY", c => c.String(maxLength: 50, storeType: "nvarchar"));
            AlterColumn("dbo.Entrada", "LAST_UPDATED_DATE", c => c.String(maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.Entrada", "LAST_UPDATED_IP", c => c.String(maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.Material", "CREATED_BY", c => c.String(maxLength: 50, storeType: "nvarchar"));
            AlterColumn("dbo.Material", "CREATION_DATE", c => c.String(maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.Material", "CREATION_IP", c => c.String(maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.Material", "LAST_UPDATED_BY", c => c.String(maxLength: 50, storeType: "nvarchar"));
            AlterColumn("dbo.Material", "LAST_UPDATED_DATE", c => c.String(maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.Material", "LAST_UPDATED_IP", c => c.String(maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.Proveedor", "CREATED_BY", c => c.String(maxLength: 50, storeType: "nvarchar"));
            AlterColumn("dbo.Proveedor", "CREATION_DATE", c => c.String(maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.Proveedor", "CREATION_IP", c => c.String(maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.Proveedor", "LAST_UPDATED_BY", c => c.String(maxLength: 50, storeType: "nvarchar"));
            AlterColumn("dbo.Proveedor", "LAST_UPDATED_DATE", c => c.String(maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.Proveedor", "LAST_UPDATED_IP", c => c.String(maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.Salida", "CREATED_BY", c => c.String(maxLength: 50, storeType: "nvarchar"));
            AlterColumn("dbo.Salida", "CREATION_DATE", c => c.String(maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.Salida", "CREATION_IP", c => c.String(maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.Salida", "LAST_UPDATED_BY", c => c.String(maxLength: 50, storeType: "nvarchar"));
            AlterColumn("dbo.Salida", "LAST_UPDATED_DATE", c => c.String(maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.Salida", "LAST_UPDATED_IP", c => c.String(maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.Personal", "CREATED_BY", c => c.String(maxLength: 50, storeType: "nvarchar"));
            AlterColumn("dbo.Personal", "CREATION_DATE", c => c.String(maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.Personal", "CREATION_IP", c => c.String(maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.Personal", "LAST_UPDATED_BY", c => c.String(maxLength: 50, storeType: "nvarchar"));
            AlterColumn("dbo.Personal", "LAST_UPDATED_DATE", c => c.String(maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.Personal", "LAST_UPDATED_IP", c => c.String(maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.OrdenPedido", "CREATED_BY", c => c.String(maxLength: 50, storeType: "nvarchar"));
            AlterColumn("dbo.OrdenPedido", "CREATION_DATE", c => c.String(maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.OrdenPedido", "CREATION_IP", c => c.String(maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.OrdenPedido", "LAST_UPDATED_BY", c => c.String(maxLength: 50, storeType: "nvarchar"));
            AlterColumn("dbo.OrdenPedido", "LAST_UPDATED_DATE", c => c.String(maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.OrdenPedido", "LAST_UPDATED_IP", c => c.String(maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.OrdenTrabajo", "CREATED_BY", c => c.String(maxLength: 50, storeType: "nvarchar"));
            AlterColumn("dbo.OrdenTrabajo", "CREATION_DATE", c => c.String(maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.OrdenTrabajo", "CREATION_IP", c => c.String(maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.OrdenTrabajo", "LAST_UPDATED_BY", c => c.String(maxLength: 50, storeType: "nvarchar"));
            AlterColumn("dbo.OrdenTrabajo", "LAST_UPDATED_DATE", c => c.String(maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.OrdenTrabajo", "LAST_UPDATED_IP", c => c.String(maxLength: 20, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrdenTrabajo", "LAST_UPDATED_IP", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.OrdenTrabajo", "LAST_UPDATED_DATE", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.OrdenTrabajo", "LAST_UPDATED_BY", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.OrdenTrabajo", "CREATION_IP", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.OrdenTrabajo", "CREATION_DATE", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.OrdenTrabajo", "CREATED_BY", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.OrdenPedido", "LAST_UPDATED_IP", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.OrdenPedido", "LAST_UPDATED_DATE", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.OrdenPedido", "LAST_UPDATED_BY", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.OrdenPedido", "CREATION_IP", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.OrdenPedido", "CREATION_DATE", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.OrdenPedido", "CREATED_BY", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Personal", "LAST_UPDATED_IP", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.Personal", "LAST_UPDATED_DATE", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.Personal", "LAST_UPDATED_BY", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Personal", "CREATION_IP", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.Personal", "CREATION_DATE", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.Personal", "CREATED_BY", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Salida", "LAST_UPDATED_IP", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.Salida", "LAST_UPDATED_DATE", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.Salida", "LAST_UPDATED_BY", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Salida", "CREATION_IP", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.Salida", "CREATION_DATE", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.Salida", "CREATED_BY", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Proveedor", "LAST_UPDATED_IP", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.Proveedor", "LAST_UPDATED_DATE", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.Proveedor", "LAST_UPDATED_BY", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Proveedor", "CREATION_IP", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.Proveedor", "CREATION_DATE", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.Proveedor", "CREATED_BY", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Material", "LAST_UPDATED_IP", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.Material", "LAST_UPDATED_DATE", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.Material", "LAST_UPDATED_BY", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Material", "CREATION_IP", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.Material", "CREATION_DATE", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.Material", "CREATED_BY", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Entrada", "LAST_UPDATED_IP", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.Entrada", "LAST_UPDATED_DATE", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.Entrada", "LAST_UPDATED_BY", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Entrada", "CREATION_IP", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.Entrada", "CREATION_DATE", c => c.String(nullable: false, maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.Entrada", "CREATED_BY", c => c.String(nullable: false, unicode: false));
        }
    }
}
