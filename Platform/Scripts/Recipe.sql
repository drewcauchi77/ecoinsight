﻿--*** Remove all items and start from ID 1
--TRUNCATE TABLE Recipe;

--*** Get any title duplicates in the table
--WITH DuplicateTitles AS (
--    SELECT Title
--    FROM Recipe
--    GROUP BY Title
--    HAVING COUNT(*) > 1
--)
--SELECT r.Title, r.SourceUrl
--FROM Recipe r
--JOIN DuplicateTitles dt
--ON r.Title = dt.Title;