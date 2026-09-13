-- Expands the crop type list to cover Maharashtra's major crops across cereals, pulses,
-- oilseeds, vegetables, fruits and spices, so the "select your crops" onboarding step has a
-- realistic list to choose from. Stage/interval data is a reasonable per-category approximation,
-- not per-crop agronomic research — good enough to drive reminders, refine later per crop if needed.
IF NOT EXISTS (SELECT 1 FROM agritrack.CropTypes WHERE Name = 'Rice')
INSERT INTO agritrack.CropTypes (Id, Name, StageDurationDaysJson, WaterIntervalDaysJson, PesticideIntervalDaysJson)
VALUES (NEWID(), 'Rice',
    '{"Sowing":0,"Germination":10,"Vegetative":45,"Flowering":20,"Fruiting":25}',
    '{"Sowing":2,"Germination":2,"Vegetative":4,"Flowering":4,"Fruiting":5}',
    '{"Vegetative":18,"Flowering":15}');

IF NOT EXISTS (SELECT 1 FROM agritrack.CropTypes WHERE Name = 'Jowar')
INSERT INTO agritrack.CropTypes (Id, Name, StageDurationDaysJson, WaterIntervalDaysJson, PesticideIntervalDaysJson)
VALUES (NEWID(), 'Jowar',
    '{"Sowing":0,"Germination":8,"Vegetative":40,"Flowering":18,"Fruiting":24}',
    '{"Sowing":6,"Germination":6,"Vegetative":9,"Flowering":8,"Fruiting":9}',
    '{"Vegetative":20,"Flowering":18}');

IF NOT EXISTS (SELECT 1 FROM agritrack.CropTypes WHERE Name = 'Bajra')
INSERT INTO agritrack.CropTypes (Id, Name, StageDurationDaysJson, WaterIntervalDaysJson, PesticideIntervalDaysJson)
VALUES (NEWID(), 'Bajra',
    '{"Sowing":0,"Germination":7,"Vegetative":35,"Flowering":15,"Fruiting":20}',
    '{"Sowing":7,"Germination":7,"Vegetative":10,"Flowering":9,"Fruiting":10}',
    '{"Vegetative":20}');

IF NOT EXISTS (SELECT 1 FROM agritrack.CropTypes WHERE Name = 'Maize')
INSERT INTO agritrack.CropTypes (Id, Name, StageDurationDaysJson, WaterIntervalDaysJson, PesticideIntervalDaysJson)
VALUES (NEWID(), 'Maize',
    '{"Sowing":0,"Germination":7,"Vegetative":40,"Flowering":18,"Fruiting":25}',
    '{"Sowing":5,"Germination":5,"Vegetative":7,"Flowering":6,"Fruiting":7}',
    '{"Vegetative":15,"Flowering":14}');

IF NOT EXISTS (SELECT 1 FROM agritrack.CropTypes WHERE Name = 'Tur')
INSERT INTO agritrack.CropTypes (Id, Name, StageDurationDaysJson, WaterIntervalDaysJson, PesticideIntervalDaysJson)
VALUES (NEWID(), 'Tur',
    '{"Sowing":0,"Germination":8,"Vegetative":50,"Flowering":25,"Fruiting":30}',
    '{"Sowing":8,"Germination":8,"Vegetative":12,"Flowering":10,"Fruiting":12}',
    '{"Vegetative":20,"Flowering":18}');

IF NOT EXISTS (SELECT 1 FROM agritrack.CropTypes WHERE Name = 'Gram')
INSERT INTO agritrack.CropTypes (Id, Name, StageDurationDaysJson, WaterIntervalDaysJson, PesticideIntervalDaysJson)
VALUES (NEWID(), 'Gram',
    '{"Sowing":0,"Germination":8,"Vegetative":35,"Flowering":15,"Fruiting":20}',
    '{"Sowing":10,"Germination":10,"Vegetative":14,"Flowering":12,"Fruiting":14}',
    '{"Vegetative":20}');

IF NOT EXISTS (SELECT 1 FROM agritrack.CropTypes WHERE Name = 'Moong')
INSERT INTO agritrack.CropTypes (Id, Name, StageDurationDaysJson, WaterIntervalDaysJson, PesticideIntervalDaysJson)
VALUES (NEWID(), 'Moong',
    '{"Sowing":0,"Germination":6,"Vegetative":25,"Flowering":12,"Fruiting":15}',
    '{"Sowing":6,"Germination":6,"Vegetative":8,"Flowering":7,"Fruiting":8}',
    '{"Vegetative":15}');

IF NOT EXISTS (SELECT 1 FROM agritrack.CropTypes WHERE Name = 'Urad')
INSERT INTO agritrack.CropTypes (Id, Name, StageDurationDaysJson, WaterIntervalDaysJson, PesticideIntervalDaysJson)
VALUES (NEWID(), 'Urad',
    '{"Sowing":0,"Germination":6,"Vegetative":25,"Flowering":12,"Fruiting":15}',
    '{"Sowing":6,"Germination":6,"Vegetative":8,"Flowering":7,"Fruiting":8}',
    '{"Vegetative":15}');

IF NOT EXISTS (SELECT 1 FROM agritrack.CropTypes WHERE Name = 'Soybean')
INSERT INTO agritrack.CropTypes (Id, Name, StageDurationDaysJson, WaterIntervalDaysJson, PesticideIntervalDaysJson)
VALUES (NEWID(), 'Soybean',
    '{"Sowing":0,"Germination":7,"Vegetative":35,"Flowering":18,"Fruiting":22}',
    '{"Sowing":6,"Germination":6,"Vegetative":8,"Flowering":7,"Fruiting":8}',
    '{"Vegetative":15,"Flowering":14}');

IF NOT EXISTS (SELECT 1 FROM agritrack.CropTypes WHERE Name = 'Groundnut')
INSERT INTO agritrack.CropTypes (Id, Name, StageDurationDaysJson, WaterIntervalDaysJson, PesticideIntervalDaysJson)
VALUES (NEWID(), 'Groundnut',
    '{"Sowing":0,"Germination":8,"Vegetative":40,"Flowering":20,"Fruiting":25}',
    '{"Sowing":7,"Germination":7,"Vegetative":9,"Flowering":8,"Fruiting":9}',
    '{"Vegetative":18}');

IF NOT EXISTS (SELECT 1 FROM agritrack.CropTypes WHERE Name = 'Sunflower')
INSERT INTO agritrack.CropTypes (Id, Name, StageDurationDaysJson, WaterIntervalDaysJson, PesticideIntervalDaysJson)
VALUES (NEWID(), 'Sunflower',
    '{"Sowing":0,"Germination":8,"Vegetative":35,"Flowering":18,"Fruiting":20}',
    '{"Sowing":6,"Germination":6,"Vegetative":8,"Flowering":7,"Fruiting":8}',
    '{"Vegetative":15}');

IF NOT EXISTS (SELECT 1 FROM agritrack.CropTypes WHERE Name = 'Potato')
INSERT INTO agritrack.CropTypes (Id, Name, StageDurationDaysJson, WaterIntervalDaysJson, PesticideIntervalDaysJson)
VALUES (NEWID(), 'Potato',
    '{"Sowing":0,"Germination":10,"Vegetative":30,"Flowering":15,"Fruiting":20}',
    '{"Sowing":4,"Germination":4,"Vegetative":5,"Flowering":5,"Fruiting":6}',
    '{"Vegetative":12,"Flowering":10}');

IF NOT EXISTS (SELECT 1 FROM agritrack.CropTypes WHERE Name = 'Brinjal')
INSERT INTO agritrack.CropTypes (Id, Name, StageDurationDaysJson, WaterIntervalDaysJson, PesticideIntervalDaysJson)
VALUES (NEWID(), 'Brinjal',
    '{"Sowing":0,"Germination":7,"Vegetative":30,"Flowering":15,"Fruiting":25}',
    '{"Sowing":2,"Germination":2,"Vegetative":3,"Flowering":3,"Fruiting":4}',
    '{"Vegetative":10,"Flowering":9,"Fruiting":10}');

IF NOT EXISTS (SELECT 1 FROM agritrack.CropTypes WHERE Name = 'Okra')
INSERT INTO agritrack.CropTypes (Id, Name, StageDurationDaysJson, WaterIntervalDaysJson, PesticideIntervalDaysJson)
VALUES (NEWID(), 'Okra',
    '{"Sowing":0,"Germination":6,"Vegetative":25,"Flowering":12,"Fruiting":20}',
    '{"Sowing":3,"Germination":3,"Vegetative":4,"Flowering":4,"Fruiting":4}',
    '{"Vegetative":10,"Flowering":9}');

IF NOT EXISTS (SELECT 1 FROM agritrack.CropTypes WHERE Name = 'Cabbage')
INSERT INTO agritrack.CropTypes (Id, Name, StageDurationDaysJson, WaterIntervalDaysJson, PesticideIntervalDaysJson)
VALUES (NEWID(), 'Cabbage',
    '{"Sowing":0,"Germination":8,"Vegetative":35,"Flowering":15,"Fruiting":15}',
    '{"Sowing":3,"Germination":3,"Vegetative":4,"Flowering":4,"Fruiting":4}',
    '{"Vegetative":10}');

IF NOT EXISTS (SELECT 1 FROM agritrack.CropTypes WHERE Name = 'Cauliflower')
INSERT INTO agritrack.CropTypes (Id, Name, StageDurationDaysJson, WaterIntervalDaysJson, PesticideIntervalDaysJson)
VALUES (NEWID(), 'Cauliflower',
    '{"Sowing":0,"Germination":8,"Vegetative":35,"Flowering":15,"Fruiting":15}',
    '{"Sowing":3,"Germination":3,"Vegetative":4,"Flowering":4,"Fruiting":4}',
    '{"Vegetative":10}');

IF NOT EXISTS (SELECT 1 FROM agritrack.CropTypes WHERE Name = 'Chili')
INSERT INTO agritrack.CropTypes (Id, Name, StageDurationDaysJson, WaterIntervalDaysJson, PesticideIntervalDaysJson)
VALUES (NEWID(), 'Chili',
    '{"Sowing":0,"Germination":7,"Vegetative":30,"Flowering":15,"Fruiting":30}',
    '{"Sowing":3,"Germination":3,"Vegetative":4,"Flowering":4,"Fruiting":5}',
    '{"Vegetative":10,"Flowering":9,"Fruiting":10}');

IF NOT EXISTS (SELECT 1 FROM agritrack.CropTypes WHERE Name = 'Grapes')
INSERT INTO agritrack.CropTypes (Id, Name, StageDurationDaysJson, WaterIntervalDaysJson, PesticideIntervalDaysJson)
VALUES (NEWID(), 'Grapes',
    '{"Sowing":0,"Germination":15,"Vegetative":90,"Flowering":30,"Fruiting":60}',
    '{"Sowing":6,"Germination":6,"Vegetative":7,"Flowering":6,"Fruiting":7}',
    '{"Vegetative":14,"Flowering":10,"Fruiting":14}');

IF NOT EXISTS (SELECT 1 FROM agritrack.CropTypes WHERE Name = 'Banana')
INSERT INTO agritrack.CropTypes (Id, Name, StageDurationDaysJson, WaterIntervalDaysJson, PesticideIntervalDaysJson)
VALUES (NEWID(), 'Banana',
    '{"Sowing":0,"Germination":20,"Vegetative":120,"Flowering":45,"Fruiting":75}',
    '{"Sowing":5,"Germination":5,"Vegetative":6,"Flowering":6,"Fruiting":6}',
    '{"Vegetative":20,"Flowering":18}');

IF NOT EXISTS (SELECT 1 FROM agritrack.CropTypes WHERE Name = 'Pomegranate')
INSERT INTO agritrack.CropTypes (Id, Name, StageDurationDaysJson, WaterIntervalDaysJson, PesticideIntervalDaysJson)
VALUES (NEWID(), 'Pomegranate',
    '{"Sowing":0,"Germination":20,"Vegetative":90,"Flowering":30,"Fruiting":90}',
    '{"Sowing":6,"Germination":6,"Vegetative":8,"Flowering":7,"Fruiting":8}',
    '{"Vegetative":18,"Flowering":15,"Fruiting":18}');

IF NOT EXISTS (SELECT 1 FROM agritrack.CropTypes WHERE Name = 'Mango')
INSERT INTO agritrack.CropTypes (Id, Name, StageDurationDaysJson, WaterIntervalDaysJson, PesticideIntervalDaysJson)
VALUES (NEWID(), 'Mango',
    '{"Sowing":0,"Germination":20,"Vegetative":120,"Flowering":40,"Fruiting":80}',
    '{"Sowing":8,"Germination":8,"Vegetative":10,"Flowering":8,"Fruiting":10}',
    '{"Vegetative":25,"Flowering":20}');

IF NOT EXISTS (SELECT 1 FROM agritrack.CropTypes WHERE Name = 'Orange')
INSERT INTO agritrack.CropTypes (Id, Name, StageDurationDaysJson, WaterIntervalDaysJson, PesticideIntervalDaysJson)
VALUES (NEWID(), 'Orange',
    '{"Sowing":0,"Germination":20,"Vegetative":110,"Flowering":35,"Fruiting":90}',
    '{"Sowing":7,"Germination":7,"Vegetative":9,"Flowering":8,"Fruiting":9}',
    '{"Vegetative":20,"Flowering":18}');

IF NOT EXISTS (SELECT 1 FROM agritrack.CropTypes WHERE Name = 'Turmeric')
INSERT INTO agritrack.CropTypes (Id, Name, StageDurationDaysJson, WaterIntervalDaysJson, PesticideIntervalDaysJson)
VALUES (NEWID(), 'Turmeric',
    '{"Sowing":0,"Germination":25,"Vegetative":120,"Flowering":30,"Fruiting":60}',
    '{"Sowing":5,"Germination":5,"Vegetative":6,"Flowering":6,"Fruiting":7}',
    '{"Vegetative":20}');

IF NOT EXISTS (SELECT 1 FROM agritrack.CropTypes WHERE Name = 'Ginger')
INSERT INTO agritrack.CropTypes (Id, Name, StageDurationDaysJson, WaterIntervalDaysJson, PesticideIntervalDaysJson)
VALUES (NEWID(), 'Ginger',
    '{"Sowing":0,"Germination":25,"Vegetative":120,"Flowering":30,"Fruiting":60}',
    '{"Sowing":5,"Germination":5,"Vegetative":6,"Flowering":6,"Fruiting":7}',
    '{"Vegetative":20}');
GO
