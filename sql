SELECT c.ScheduleEventId, c.NextEventDate, c.OtherFields
FROM c
JOIN (
    SELECT c.ScheduleEventId, MAX(c.NextEventDate) AS LatestEventDate
    FROM c
    WHERE c.NextEventDate = GetCurrentDate()
    GROUP BY c.ScheduleEventId
) AS latestEvents
ON c.ScheduleEventId = latestEvents.ScheduleEventId AND c.NextEventDate = latestEvents.LatestEventDate
WHERE c.NextEventDate = GetCurrentDate()