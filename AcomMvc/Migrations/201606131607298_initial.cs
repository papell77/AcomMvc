namespace AcomMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.agents",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        agentName = c.String(nullable: false, maxLength: 255),
                        agentUserID = c.String(nullable: false, maxLength: 128),
                        note = c.String(maxLength: 512),
                        annull = c.Boolean(nullable: false),
                        createdBy = c.String(),
                        createdDate = c.DateTime(),
                        updatedBy = c.String(),
                        updatedDate = c.DateTime(),
                        rowvers = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.agentUserID, cascadeDelete: true)
                .Index(t => t.agentUserID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        fullName = c.String(),
                        firstName = c.String(),
                        surname = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.clients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        clientCode = c.String(nullable: false, maxLength: 64),
                        clientRagioneSociale = c.String(nullable: false, maxLength: 255),
                        clientCF = c.String(maxLength: 16),
                        clientPiva = c.String(maxLength: 11),
                        clientPivaCee = c.String(maxLength: 14),
                        clientLegalCap = c.String(maxLength: 5),
                        clientLegalAddress = c.String(maxLength: 512),
                        clientOperativeCap = c.String(maxLength: 5),
                        clientOperativeAddress = c.String(maxLength: 512),
                        clientPhone = c.String(maxLength: 64),
                        clientEmail = c.String(maxLength: 255),
                        invoiceMethod = c.String(maxLength: 64),
                        bankName = c.String(maxLength: 255),
                        ibanCode = c.String(maxLength: 27),
                        fatturato = c.Decimal(precision: 18, scale: 2),
                        fatturatoPotenziale = c.Decimal(precision: 18, scale: 2),
                        fidoRichiesto = c.Decimal(precision: 18, scale: 2),
                        fidoConcesso = c.Decimal(precision: 18, scale: 2),
                        scadenzaFido = c.DateTime(),
                        fondazione = c.DateTime(),
                        possedimenti = c.String(maxLength: 512),
                        dipendenti = c.Decimal(precision: 18, scale: 2),
                        countyLegalID = c.Int(),
                        countyOperativeID = c.Int(),
                        cityLegalID = c.Int(),
                        cityOperativeID = c.Int(),
                        canalID = c.Int(),
                        paymentID = c.Int(),
                        shipmentID = c.Int(),
                        agentID = c.Int(),
                        note = c.String(maxLength: 512),
                        annull = c.Boolean(nullable: false),
                        createdBy = c.String(),
                        createdDate = c.DateTime(),
                        updatedBy = c.String(),
                        updatedDate = c.DateTime(),
                        rowvers = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        county_ID = c.Int(),
                        city_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.agents", t => t.agentID)
                .ForeignKey("dbo.canals", t => t.canalID)
                .ForeignKey("dbo.counties", t => t.county_ID)
                .ForeignKey("dbo.cities", t => t.city_ID)
                .ForeignKey("dbo.cities", t => t.cityLegalID)
                .ForeignKey("dbo.cities", t => t.cityOperativeID)
                .ForeignKey("dbo.counties", t => t.countyLegalID)
                .ForeignKey("dbo.counties", t => t.countyOperativeID)
                .ForeignKey("dbo.payments", t => t.paymentID)
                .ForeignKey("dbo.shipments", t => t.shipmentID)
                .Index(t => t.countyLegalID)
                .Index(t => t.countyOperativeID)
                .Index(t => t.cityLegalID)
                .Index(t => t.cityOperativeID)
                .Index(t => t.canalID)
                .Index(t => t.paymentID)
                .Index(t => t.shipmentID)
                .Index(t => t.agentID)
                .Index(t => t.county_ID)
                .Index(t => t.city_ID);
            
            CreateTable(
                "dbo.canals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        canalCode = c.String(nullable: false, maxLength: 32),
                        canalDesc = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.canalCode, unique: true, name: "IX_canalcode");
            
            CreateTable(
                "dbo.cities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        cityName = c.String(nullable: false, maxLength: 255),
                        cap = c.String(nullable: false, maxLength: 5),
                        countyID = c.Int(nullable: false),
                        note = c.String(maxLength: 512),
                        annull = c.Boolean(nullable: false),
                        createdBy = c.String(),
                        createdDate = c.DateTime(),
                        updatedBy = c.String(),
                        updatedDate = c.DateTime(),
                        rowvers = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.counties", t => t.countyID, cascadeDelete: true)
                .Index(t => t.countyID);
            
            CreateTable(
                "dbo.clientOffices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        clientOfficeName = c.String(nullable: false, maxLength: 255),
                        clientOfficeCap = c.String(maxLength: 5),
                        clientOfficeAddress = c.String(maxLength: 255),
                        clientOfficePhone = c.String(maxLength: 64),
                        clientOfficeEmail = c.String(maxLength: 255),
                        clientID = c.Int(nullable: false),
                        countyID = c.Int(),
                        cityID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.cities", t => t.cityID)
                .ForeignKey("dbo.clients", t => t.clientID, cascadeDelete: true)
                .ForeignKey("dbo.counties", t => t.countyID)
                .Index(t => t.clientOfficeName, unique: true)
                .Index(t => t.clientID)
                .Index(t => t.countyID)
                .Index(t => t.cityID);
            
            CreateTable(
                "dbo.clientContacts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        firstName = c.String(maxLength: 255),
                        surname = c.String(nullable: false, maxLength: 255),
                        phone = c.String(maxLength: 64),
                        cellPhone = c.String(maxLength: 64),
                        email = c.String(maxLength: 255),
                        businessFunction = c.String(maxLength: 255),
                        clientID = c.Int(),
                        clientOfficeID = c.Int(),
                        note = c.String(maxLength: 512),
                        annull = c.Boolean(nullable: false),
                        createdBy = c.String(),
                        createdDate = c.DateTime(),
                        updatedBy = c.String(),
                        updatedDate = c.DateTime(),
                        rowvers = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.clients", t => t.clientID)
                .ForeignKey("dbo.clientOffices", t => t.clientOfficeID)
                .Index(t => t.clientID)
                .Index(t => t.clientOfficeID);
            
            CreateTable(
                "dbo.counties",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        countyName = c.String(nullable: false, maxLength: 255),
                        countySign = c.String(maxLength: 4),
                        note = c.String(maxLength: 512),
                        annull = c.Boolean(nullable: false),
                        createdBy = c.String(),
                        createdDate = c.DateTime(),
                        updatedBy = c.String(),
                        updatedDate = c.DateTime(),
                        rowvers = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.offers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        offerNum = c.Int(nullable: false),
                        offerVers = c.Int(nullable: false),
                        offerCode = c.String(maxLength: 32),
                        offerEst = c.String(maxLength: 32),
                        offerDate = c.DateTime(nullable: false),
                        offerExpiryDate = c.DateTime(nullable: false),
                        offerReference = c.String(maxLength: 255),
                        offerState = c.Int(nullable: false),
                        offerAmount = c.Decimal(precision: 18, scale: 2),
                        offerShippingCost = c.Decimal(precision: 18, scale: 2),
                        offerDeliveryTime = c.String(maxLength: 255),
                        offerPackaging = c.String(maxLength: 255),
                        pricelistTypeID = c.Int(nullable: false),
                        clientID = c.Int(nullable: false),
                        clientOfficeID = c.Int(),
                        familyID = c.Int(),
                        agentID = c.Int(),
                        clientContactID = c.Int(),
                        paymentID = c.Int(),
                        shipmentID = c.Int(),
                        deliveryID = c.Int(),
                        warrantyID = c.Int(),
                        note = c.String(maxLength: 512),
                        annull = c.Boolean(nullable: false),
                        createdBy = c.String(),
                        createdDate = c.DateTime(),
                        updatedBy = c.String(),
                        updatedDate = c.DateTime(),
                        rowvers = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.agents", t => t.agentID)
                .ForeignKey("dbo.clients", t => t.clientID, cascadeDelete: true)
                .ForeignKey("dbo.clientContacts", t => t.clientContactID)
                .ForeignKey("dbo.clientOffices", t => t.clientOfficeID)
                .ForeignKey("dbo.deliveries", t => t.deliveryID)
                .ForeignKey("dbo.families", t => t.familyID)
                .ForeignKey("dbo.payments", t => t.paymentID)
                .ForeignKey("dbo.pricelistTypes", t => t.pricelistTypeID, cascadeDelete: true)
                .ForeignKey("dbo.shipments", t => t.shipmentID)
                .ForeignKey("dbo.warranties", t => t.warrantyID)
                .Index(t => t.offerCode, unique: true)
                .Index(t => t.pricelistTypeID)
                .Index(t => t.clientID)
                .Index(t => t.clientOfficeID)
                .Index(t => t.familyID)
                .Index(t => t.agentID)
                .Index(t => t.clientContactID)
                .Index(t => t.paymentID)
                .Index(t => t.shipmentID)
                .Index(t => t.deliveryID)
                .Index(t => t.warrantyID);
            
            CreateTable(
                "dbo.deliveries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        deliveryDesc = c.String(nullable: false, maxLength: 255),
                        note = c.String(maxLength: 512),
                        annull = c.Boolean(nullable: false),
                        createdBy = c.String(),
                        createdDate = c.DateTime(),
                        updatedBy = c.String(),
                        updatedDate = c.DateTime(),
                        rowvers = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.deliveryDesc, unique: true, name: "IX_delivery");
            
            CreateTable(
                "dbo.families",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        familyDesc = c.String(nullable: false, maxLength: 255),
                        note = c.String(maxLength: 512),
                        annull = c.Boolean(nullable: false),
                        createdBy = c.String(),
                        createdDate = c.DateTime(),
                        updatedBy = c.String(),
                        updatedDate = c.DateTime(),
                        rowvers = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.familyDesc, unique: true, name: "IX_family");
            
            CreateTable(
                "dbo.pricelists",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        articleCode = c.String(nullable: false, maxLength: 64),
                        articleDesc = c.String(maxLength: 512),
                        articlePrice = c.Decimal(precision: 18, scale: 2),
                        articleEffectiveDate = c.DateTime(),
                        pricelistTypeID = c.Int(nullable: false),
                        familyID = c.Int(),
                        productID = c.Int(),
                        note = c.String(maxLength: 512),
                        annull = c.Boolean(nullable: false),
                        createdBy = c.String(),
                        createdDate = c.DateTime(),
                        updatedBy = c.String(),
                        updatedDate = c.DateTime(),
                        rowvers = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.families", t => t.familyID)
                .ForeignKey("dbo.pricelistTypes", t => t.pricelistTypeID, cascadeDelete: true)
                .ForeignKey("dbo.products", t => t.productID)
                .Index(t => t.articleCode, unique: true)
                .Index(t => new { t.articleCode, t.articleEffectiveDate }, unique: true, name: "IX_articleCode_EffectiveDate")
                .Index(t => t.pricelistTypeID)
                .Index(t => t.familyID)
                .Index(t => t.productID);
            
            CreateTable(
                "dbo.offerRows",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        rigaID = c.Int(nullable: false),
                        articleID = c.Int(nullable: false),
                        quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        discount1 = c.Decimal(precision: 18, scale: 2),
                        discount2 = c.Decimal(precision: 18, scale: 2),
                        discount3 = c.Decimal(precision: 18, scale: 2),
                        discount4 = c.Decimal(precision: 18, scale: 2),
                        discount5 = c.Decimal(precision: 18, scale: 2),
                        discount6 = c.Decimal(precision: 18, scale: 2),
                        total = c.Decimal(precision: 18, scale: 2),
                        offerID = c.Int(nullable: false),
                        note = c.String(maxLength: 512),
                        annull = c.Boolean(nullable: false),
                        createdBy = c.String(),
                        createdDate = c.DateTime(),
                        updatedBy = c.String(),
                        updatedDate = c.DateTime(),
                        rowvers = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.pricelists", t => t.articleID, cascadeDelete: true)
                .ForeignKey("dbo.offers", t => t.offerID, cascadeDelete: false)
                .Index(t => t.articleID)
                .Index(t => t.offerID);
            
            CreateTable(
                "dbo.pricelistTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        pricelistDesc = c.String(nullable: false, maxLength: 255),
                        note = c.String(maxLength: 512),
                        annull = c.Boolean(nullable: false),
                        createdBy = c.String(),
                        createdDate = c.DateTime(),
                        updatedBy = c.String(),
                        updatedDate = c.DateTime(),
                        rowvers = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.pricelistDesc, unique: true, name: "IX_pricelist");
            
            CreateTable(
                "dbo.products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        productDesc = c.String(nullable: false, maxLength: 255),
                        note = c.String(maxLength: 512),
                        annull = c.Boolean(nullable: false),
                        createdBy = c.String(),
                        createdDate = c.DateTime(),
                        updatedBy = c.String(),
                        updatedDate = c.DateTime(),
                        rowvers = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.productDesc, unique: true, name: "IX_product");
            
            CreateTable(
                "dbo.orderRows",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        rigaID = c.Int(nullable: false),
                        orderRowQuantity = c.Int(),
                        orderID = c.Int(nullable: false),
                        productID = c.Int(nullable: false),
                        note = c.String(maxLength: 512),
                        annull = c.Boolean(nullable: false),
                        createdBy = c.String(),
                        createdDate = c.DateTime(),
                        updatedBy = c.String(),
                        updatedDate = c.DateTime(),
                        rowvers = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.orders", t => t.orderID, cascadeDelete: true)
                .ForeignKey("dbo.products", t => t.productID, cascadeDelete: true)
                .Index(t => t.orderID)
                .Index(t => t.productID);
            
            CreateTable(
                "dbo.orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        orderCode = c.String(maxLength: 32),
                        orderNum = c.Int(nullable: false),
                        orderSap = c.String(maxLength: 32),
                        orderDate = c.DateTime(nullable: false),
                        orderAmount = c.Decimal(precision: 18, scale: 2),
                        orderRifImpianto = c.String(maxLength: 255),
                        orderRifOfferta = c.String(maxLength: 255),
                        orderRifOffertaEst = c.String(maxLength: 255),
                        orderRifOrdine = c.String(maxLength: 255),
                        clientID = c.Int(nullable: false),
                        clientOfficeID = c.Int(),
                        agentID = c.Int(),
                        note = c.String(maxLength: 512),
                        annull = c.Boolean(nullable: false),
                        createdBy = c.String(),
                        createdDate = c.DateTime(),
                        updatedBy = c.String(),
                        updatedDate = c.DateTime(),
                        rowvers = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.agents", t => t.agentID)
                .ForeignKey("dbo.clients", t => t.clientID, cascadeDelete: true)
                .ForeignKey("dbo.clientOffices", t => t.clientOfficeID)
                .Index(t => t.clientID)
                .Index(t => t.clientOfficeID)
                .Index(t => t.agentID);
            
            CreateTable(
                "dbo.payments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        paymentDesc = c.String(nullable: false, maxLength: 255),
                        note = c.String(maxLength: 512),
                        annull = c.Boolean(nullable: false),
                        createdBy = c.String(),
                        createdDate = c.DateTime(),
                        updatedBy = c.String(),
                        updatedDate = c.DateTime(),
                        rowvers = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.paymentDesc, unique: true, name: "IX_payment");
            
            CreateTable(
                "dbo.shipments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        shipmentDesc = c.String(nullable: false, maxLength: 255),
                        note = c.String(maxLength: 512),
                        annull = c.Boolean(nullable: false),
                        createdBy = c.String(),
                        createdDate = c.DateTime(),
                        updatedBy = c.String(),
                        updatedDate = c.DateTime(),
                        rowvers = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.shipmentDesc, unique: true, name: "IX_shipment");
            
            CreateTable(
                "dbo.warranties",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        warrantyDesc = c.String(nullable: false, maxLength: 255),
                        note = c.String(maxLength: 512),
                        annull = c.Boolean(nullable: false),
                        createdBy = c.String(),
                        createdDate = c.DateTime(),
                        updatedBy = c.String(),
                        updatedDate = c.DateTime(),
                        rowvers = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.warrantyDesc, unique: true, name: "IX_warranty");
            
            CreateTable(
                "dbo.visits",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        visitDate = c.DateTime(nullable: false),
                        agentID = c.Int(nullable: false),
                        visitMotivo = c.Int(nullable: false),
                        visitDesc = c.String(maxLength: 255),
                        visitNextDate = c.DateTime(),
                        stato = c.Int(nullable: false),
                        visitOfferYear = c.Int(),
                        visitOfferID = c.Int(),
                        visitOrderID = c.Int(),
                        clientID = c.Int(),
                        clientOfficeID = c.Int(),
                        note = c.String(maxLength: 512),
                        annull = c.Boolean(nullable: false),
                        createdBy = c.String(),
                        createdDate = c.DateTime(),
                        updatedBy = c.String(),
                        updatedDate = c.DateTime(),
                        rowvers = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.agents", t => t.agentID, cascadeDelete: true)
                .ForeignKey("dbo.clients", t => t.clientID)
                .ForeignKey("dbo.clientOffices", t => t.clientOfficeID)
                .ForeignKey("dbo.offers", t => t.visitOfferID)
                .ForeignKey("dbo.orders", t => t.visitOrderID)
                .Index(t => t.agentID)
                .Index(t => t.visitOfferID)
                .Index(t => t.visitOrderID)
                .Index(t => t.clientID)
                .Index(t => t.clientOfficeID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.clients", "shipmentID", "dbo.shipments");
            DropForeignKey("dbo.clients", "paymentID", "dbo.payments");
            DropForeignKey("dbo.clients", "countyOperativeID", "dbo.counties");
            DropForeignKey("dbo.clients", "countyLegalID", "dbo.counties");
            DropForeignKey("dbo.clients", "cityOperativeID", "dbo.cities");
            DropForeignKey("dbo.clients", "cityLegalID", "dbo.cities");
            DropForeignKey("dbo.cities", "countyID", "dbo.counties");
            DropForeignKey("dbo.clients", "city_ID", "dbo.cities");
            DropForeignKey("dbo.visits", "visitOrderID", "dbo.orders");
            DropForeignKey("dbo.visits", "visitOfferID", "dbo.offers");
            DropForeignKey("dbo.visits", "clientOfficeID", "dbo.clientOffices");
            DropForeignKey("dbo.visits", "clientID", "dbo.clients");
            DropForeignKey("dbo.visits", "agentID", "dbo.agents");
            DropForeignKey("dbo.offers", "warrantyID", "dbo.warranties");
            DropForeignKey("dbo.offers", "shipmentID", "dbo.shipments");
            DropForeignKey("dbo.offers", "pricelistTypeID", "dbo.pricelistTypes");
            DropForeignKey("dbo.offers", "paymentID", "dbo.payments");
            DropForeignKey("dbo.offers", "familyID", "dbo.families");
            DropForeignKey("dbo.pricelists", "productID", "dbo.products");
            DropForeignKey("dbo.orderRows", "productID", "dbo.products");
            DropForeignKey("dbo.orderRows", "orderID", "dbo.orders");
            DropForeignKey("dbo.orders", "clientOfficeID", "dbo.clientOffices");
            DropForeignKey("dbo.orders", "clientID", "dbo.clients");
            DropForeignKey("dbo.orders", "agentID", "dbo.agents");
            DropForeignKey("dbo.pricelists", "pricelistTypeID", "dbo.pricelistTypes");
            DropForeignKey("dbo.offerRows", "offerID", "dbo.offers");
            DropForeignKey("dbo.offerRows", "articleID", "dbo.pricelists");
            DropForeignKey("dbo.pricelists", "familyID", "dbo.families");
            DropForeignKey("dbo.offers", "deliveryID", "dbo.deliveries");
            DropForeignKey("dbo.offers", "clientOfficeID", "dbo.clientOffices");
            DropForeignKey("dbo.offers", "clientContactID", "dbo.clientContacts");
            DropForeignKey("dbo.offers", "clientID", "dbo.clients");
            DropForeignKey("dbo.offers", "agentID", "dbo.agents");
            DropForeignKey("dbo.clientOffices", "countyID", "dbo.counties");
            DropForeignKey("dbo.clients", "county_ID", "dbo.counties");
            DropForeignKey("dbo.clientContacts", "clientOfficeID", "dbo.clientOffices");
            DropForeignKey("dbo.clientContacts", "clientID", "dbo.clients");
            DropForeignKey("dbo.clientOffices", "clientID", "dbo.clients");
            DropForeignKey("dbo.clientOffices", "cityID", "dbo.cities");
            DropForeignKey("dbo.clients", "canalID", "dbo.canals");
            DropForeignKey("dbo.clients", "agentID", "dbo.agents");
            DropForeignKey("dbo.agents", "agentUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.visits", new[] { "clientOfficeID" });
            DropIndex("dbo.visits", new[] { "clientID" });
            DropIndex("dbo.visits", new[] { "visitOrderID" });
            DropIndex("dbo.visits", new[] { "visitOfferID" });
            DropIndex("dbo.visits", new[] { "agentID" });
            DropIndex("dbo.warranties", "IX_warranty");
            DropIndex("dbo.shipments", "IX_shipment");
            DropIndex("dbo.payments", "IX_payment");
            DropIndex("dbo.orders", new[] { "agentID" });
            DropIndex("dbo.orders", new[] { "clientOfficeID" });
            DropIndex("dbo.orders", new[] { "clientID" });
            DropIndex("dbo.orderRows", new[] { "productID" });
            DropIndex("dbo.orderRows", new[] { "orderID" });
            DropIndex("dbo.products", "IX_product");
            DropIndex("dbo.pricelistTypes", "IX_pricelist");
            DropIndex("dbo.offerRows", new[] { "offerID" });
            DropIndex("dbo.offerRows", new[] { "articleID" });
            DropIndex("dbo.pricelists", new[] { "productID" });
            DropIndex("dbo.pricelists", new[] { "familyID" });
            DropIndex("dbo.pricelists", new[] { "pricelistTypeID" });
            DropIndex("dbo.pricelists", "IX_articleCode_EffectiveDate");
            DropIndex("dbo.pricelists", new[] { "articleCode" });
            DropIndex("dbo.families", "IX_family");
            DropIndex("dbo.deliveries", "IX_delivery");
            DropIndex("dbo.offers", new[] { "warrantyID" });
            DropIndex("dbo.offers", new[] { "deliveryID" });
            DropIndex("dbo.offers", new[] { "shipmentID" });
            DropIndex("dbo.offers", new[] { "paymentID" });
            DropIndex("dbo.offers", new[] { "clientContactID" });
            DropIndex("dbo.offers", new[] { "agentID" });
            DropIndex("dbo.offers", new[] { "familyID" });
            DropIndex("dbo.offers", new[] { "clientOfficeID" });
            DropIndex("dbo.offers", new[] { "clientID" });
            DropIndex("dbo.offers", new[] { "pricelistTypeID" });
            DropIndex("dbo.offers", new[] { "offerCode" });
            DropIndex("dbo.clientContacts", new[] { "clientOfficeID" });
            DropIndex("dbo.clientContacts", new[] { "clientID" });
            DropIndex("dbo.clientOffices", new[] { "cityID" });
            DropIndex("dbo.clientOffices", new[] { "countyID" });
            DropIndex("dbo.clientOffices", new[] { "clientID" });
            DropIndex("dbo.clientOffices", new[] { "clientOfficeName" });
            DropIndex("dbo.cities", new[] { "countyID" });
            DropIndex("dbo.canals", "IX_canalcode");
            DropIndex("dbo.clients", new[] { "city_ID" });
            DropIndex("dbo.clients", new[] { "county_ID" });
            DropIndex("dbo.clients", new[] { "agentID" });
            DropIndex("dbo.clients", new[] { "shipmentID" });
            DropIndex("dbo.clients", new[] { "paymentID" });
            DropIndex("dbo.clients", new[] { "canalID" });
            DropIndex("dbo.clients", new[] { "cityOperativeID" });
            DropIndex("dbo.clients", new[] { "cityLegalID" });
            DropIndex("dbo.clients", new[] { "countyOperativeID" });
            DropIndex("dbo.clients", new[] { "countyLegalID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.agents", new[] { "agentUserID" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.visits");
            DropTable("dbo.warranties");
            DropTable("dbo.shipments");
            DropTable("dbo.payments");
            DropTable("dbo.orders");
            DropTable("dbo.orderRows");
            DropTable("dbo.products");
            DropTable("dbo.pricelistTypes");
            DropTable("dbo.offerRows");
            DropTable("dbo.pricelists");
            DropTable("dbo.families");
            DropTable("dbo.deliveries");
            DropTable("dbo.offers");
            DropTable("dbo.counties");
            DropTable("dbo.clientContacts");
            DropTable("dbo.clientOffices");
            DropTable("dbo.cities");
            DropTable("dbo.canals");
            DropTable("dbo.clients");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.agents");
        }
    }
}
