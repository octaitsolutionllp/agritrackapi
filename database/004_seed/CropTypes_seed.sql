-- Seed a handful of common crop types with stage durations (days) and care intervals (days), per stage.
-- StageDurationDaysJson: how many days a cycle typically spends in each stage before advancing.
-- WaterIntervalDaysJson: how often to water while in that stage.
-- PesticideIntervalDaysJson: how often to apply pesticide while in that stage (stages omitted = no pesticide reminder).
IF NOT EXISTS (SELECT 1 FROM agritrack.CropTypes WHERE Name = 'Tomato')
INSERT INTO agritrack.CropTypes (Id, Name, StageDurationDaysJson, WaterIntervalDaysJson, PesticideIntervalDaysJson)
VALUES (NEWID(), 'Tomato',
    '{"Sowing":0,"Germination":7,"Vegetative":30,"Flowering":20,"Fruiting":25}',
    '{"Sowing":2,"Germination":2,"Vegetative":3,"Flowering":2,"Fruiting":3}',
    '{"Vegetative":14,"Flowering":10,"Fruiting":14}');

IF NOT EXISTS (SELECT 1 FROM agritrack.CropTypes WHERE Name = 'Wheat')
INSERT INTO agritrack.CropTypes (Id, Name, StageDurationDaysJson, WaterIntervalDaysJson, PesticideIntervalDaysJson)
VALUES (NEWID(), 'Wheat',
    '{"Sowing":0,"Germination":10,"Vegetative":45,"Flowering":20,"Fruiting":30}',
    '{"Sowing":5,"Germination":5,"Vegetative":10,"Flowering":8,"Fruiting":10}',
    '{"Vegetative":21,"Flowering":18}');

IF NOT EXISTS (SELECT 1 FROM agritrack.CropTypes WHERE Name = 'Onion')
INSERT INTO agritrack.CropTypes (Id, Name, StageDurationDaysJson, WaterIntervalDaysJson, PesticideIntervalDaysJson)
VALUES (NEWID(), 'Onion',
    '{"Sowing":0,"Germination":10,"Vegetative":40,"Flowering":15,"Fruiting":25}',
    '{"Sowing":3,"Germination":3,"Vegetative":5,"Flowering":5,"Fruiting":6}',
    '{"Vegetative":15,"Flowering":15,"Fruiting":15}');

IF NOT EXISTS (SELECT 1 FROM agritrack.CropTypes WHERE Name = 'Cotton')
INSERT INTO agritrack.CropTypes (Id, Name, StageDurationDaysJson, WaterIntervalDaysJson, PesticideIntervalDaysJson)
VALUES (NEWID(), 'Cotton',
    '{"Sowing":0,"Germination":10,"Vegetative":50,"Flowering":30,"Fruiting":40}',
    '{"Sowing":6,"Germination":6,"Vegetative":10,"Flowering":8,"Fruiting":10}',
    '{"Vegetative":14,"Flowering":10,"Fruiting":14}');

IF NOT EXISTS (SELECT 1 FROM agritrack.CropTypes WHERE Name = 'Sugarcane')
INSERT INTO agritrack.CropTypes (Id, Name, StageDurationDaysJson, WaterIntervalDaysJson, PesticideIntervalDaysJson)
VALUES (NEWID(), 'Sugarcane',
    '{"Sowing":0,"Germination":30,"Vegetative":150,"Flowering":60,"Fruiting":60}',
    '{"Sowing":7,"Germination":7,"Vegetative":10,"Flowering":10,"Fruiting":12}',
    '{"Vegetative":30,"Flowering":30}');
GO
