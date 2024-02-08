USE KemiDB;

--Product Groups
INSERT INTO [dbo].[ProductGroups] ([GroupName], [Remarks])
VALUES
    ('Olieprodukter', 'Produkter, der anvendes som smøre- og glidemidler f.eks smørefedt og olie. motorolie og skæreolie.'),
    ('Rengørngsmidler', 'Produkter der anvendes til afrensning, affedtning og afkalkning af forskellige overflade. For eksempel maskinopvaskemidler, håndopvaskemidler, kalkfjerner, glasrens med videre.'),
    ('Maling, lak, lim eller fugemasse', 'Produkter, der anvendes til overfladebehandling, sammenføjning (limning) og f.eks. vægmaling, sekundlim, samt produkter der anvendes til fortynding eller forudgående rengøring før maling og limning. Produkterne i denne kategori er kendetegnet ved at de skal være forsynet med et kodenummer – se afsnit D.'),
    ('Brændstof og tilsætningsstoffer til brændstof', 'Produkter, der anvendes som brændstof f.eks. diesel til påhængsmotorer, benzin og produkter, der er beregnet som tilsætning til brændstof.'),
    ('Vandbehandlingskemikalier', 'Produkter, der tilsættes vand f.eks. kedelvand med henblik på at undgå korrosion, justere pH m.v.'),
    ('Andre', 'Her placeres produkter, der ikke falder ind under nogen af de ovenstående kategorier. Det vil typisk være flusmidler, analysekemikalier, trykflasker o.l.')

--Product Categories
-- Inserting categories for 'Olieprodukter' group
INSERT INTO [dbo].[ProductCategories] ([ProductGroupId], [Category])
VALUES
    (1, 'Motorolie'),
    (1, 'Smøremidler'),
    (1, 'Hydraulikolie');

-- Inserting categories for 'Rengørngsmidler' group
INSERT INTO [dbo].[ProductCategories] ([ProductGroupId], [Category])
VALUES
    (2, 'Almindelige rengøringsmidler'),
    (2, 'Desinfektionsmidler'),
    (2, 'Industrielle rengøringsmidler');

-- Inserting categories for 'Maling, lak, lim eller fugemasse' group
INSERT INTO [dbo].[ProductCategories] ([ProductGroupId], [Category])
VALUES
    (3, 'Industriel maling'),
    (3, 'Lak'),
    (3, 'Lim');

-- Inserting categories for 'Brændstof og tilsætningsstoffer til brændstof' group
INSERT INTO [dbo].[ProductCategories] ([ProductGroupId], [Category])
VALUES
    (4, 'Benzin'),
    (4, 'Diesel'),
    (4, 'Tilsætningsstoffer til brændstof');

-- Inserting categories for 'Vandbehandlingskemikalier' group
INSERT INTO [dbo].[ProductCategories] ([ProductGroupId], [Category])
VALUES
    (5, 'Filtreringsmidler'),
    (5, 'Desinfektionsmidler til vand'),
    (5, 'pH-reguleringsmidler');

-- Inserting categories for 'Andre' group
INSERT INTO [dbo].[ProductCategories] ([ProductGroupId], [Category])
VALUES
    (6, 'Specialkemikalier'),
    (6, 'Industrikemikalier'),
    (6, 'Husholdningskemikalier');

