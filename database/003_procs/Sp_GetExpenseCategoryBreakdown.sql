-- Combines the Expenses table with any Cost logged alongside an Activity (mapped to the
-- closest expense category) so a farmer only has to enter a cost once, wherever is natural —
-- on the Log Activity form or the Expenses page — and it counts toward totals either way.
CREATE OR ALTER PROCEDURE agritrack.Sp_GetExpenseCategoryBreakdown
    @CropCycleId UNIQUEIDENTIFIER,
    @UserId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Category, SUM(Amount) AS Amount
    FROM (
        SELECT Category, Amount
        FROM agritrack.Expenses
        WHERE CropCycleId = @CropCycleId AND UserId = @UserId

        UNION ALL

        SELECT
            CASE ActivityType
                WHEN 'Water' THEN 'Irrigation'
                WHEN 'Pesticide' THEN 'Pesticide'
                WHEN 'Fertilizer' THEN 'Fertilizer'
                WHEN 'Weeding' THEN 'Labor'
                WHEN 'EarthingUp' THEN 'Labor'
                WHEN 'Sieving' THEN 'Labor'
                ELSE 'Other'
            END AS Category,
            Cost AS Amount
        FROM agritrack.Activities
        WHERE CropCycleId = @CropCycleId AND UserId = @UserId AND Cost IS NOT NULL
    ) combined
    GROUP BY Category
    ORDER BY SUM(Amount) DESC;
END
GO
