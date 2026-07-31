using System;

class Program
{
    static void Main(string[] args)
    {
        PatientVital[] records =
        {
            new PatientVital
            {
                HeartRate = 75,
                OxygenLevel = 98,
                SystolicBP = 120,
                DiastolicBP = 80,
                Time = "09:00"
            },

            new PatientVital
            {
                HeartRate = 110,
                OxygenLevel = 92,
                SystolicBP = 145,
                DiastolicBP = 95,
                Time = "09:01"
            },

            new PatientVital
            {
                HeartRate = 68,
                OxygenLevel = 99,
                SystolicBP = 118,
                DiastolicBP = 78,
                Time = "09:02"
            },

            new PatientVital
            {
                HeartRate = 130,
                OxygenLevel = 88,
                SystolicBP = 160,
                DiastolicBP = 100,
                Time = "09:03"
            },

            new PatientVital
            {
                HeartRate = 82,
                OxygenLevel = 97,
                SystolicBP = 122,
                DiastolicBP = 82,
                Time = "09:04"
            }
        };

        DisplayRecords(records);

        Console.WriteLine();

        DisplayAbnormalRecords(records);

        Console.WriteLine();

        SearchByTime(records, "09:03");

        Console.WriteLine();

        CalculateAverageHeartRate(records);

        Console.WriteLine();

        FindMaximumHeartRate(records);

        Console.WriteLine();

        SortHeartRate(records);

        Console.WriteLine();

        FindMedianHeartRate(records);

        Console.WriteLine();

        SlidingWindowAverage(records);
    }

    // Display all patient records
    static void DisplayRecords(PatientVital[] records)
    {
        Console.WriteLine("========== ICU Patient Records ==========\n");

        foreach (PatientVital patient in records)
        {
            Console.WriteLine("Time            : " + patient.Time);
            Console.WriteLine("Heart Rate      : " + patient.HeartRate + " BPM");
            Console.WriteLine("Oxygen Level    : " + patient.OxygenLevel + "%");
            Console.WriteLine("Blood Pressure  : " + patient.SystolicBP + "/" + patient.DiastolicBP + " mmHg");
            Console.WriteLine("------------------------------------------");
        }
    }

    // Display abnormal patient records
    static void DisplayAbnormalRecords(PatientVital[] records)
    {
        Console.WriteLine("========== Abnormal Vital Signs ==========\n");

        foreach (PatientVital patient in records)
        {
            if (patient.HeartRate > 100 ||
                patient.OxygenLevel < 95 ||
                patient.SystolicBP > 140 ||
                patient.DiastolicBP > 90)
            {
                Console.WriteLine("Time            : " + patient.Time);
                Console.WriteLine("Heart Rate      : " + patient.HeartRate);
                Console.WriteLine("Oxygen Level    : " + patient.OxygenLevel);
                Console.WriteLine("Blood Pressure  : " + patient.SystolicBP + "/" + patient.DiastolicBP);
                Console.WriteLine("Status          : ALERT");
                Console.WriteLine();
            }
        }
    }

    // Search patient by timestamp
    static void SearchByTime(PatientVital[] records, string time)
    {
        Console.WriteLine("========== Search Result ==========\n");

        bool found = false;

        foreach (PatientVital patient in records)
        {
            if (patient.Time == time)
            {
                Console.WriteLine("Time            : " + patient.Time);
                Console.WriteLine("Heart Rate      : " + patient.HeartRate);
                Console.WriteLine("Oxygen Level    : " + patient.OxygenLevel);
                Console.WriteLine("Blood Pressure  : " + patient.SystolicBP + "/" + patient.DiastolicBP);

                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("Record Not Found");
        }
    }

    // Calculate average heart rate
    static void CalculateAverageHeartRate(PatientVital[] records)
    {
        int sum = 0;

        foreach (PatientVital patient in records)
        {
            sum += patient.HeartRate;
        }

        double average = (double)sum / records.Length;

        Console.WriteLine("Average Heart Rate : " + average + " BPM");
    }

    // Find highest heart rate
    static void FindMaximumHeartRate(PatientVital[] records)
    {
        int max = records[0].HeartRate;

        for (int i = 1; i < records.Length; i++)
        {
            if (records[i].HeartRate > max)
            {
                max = records[i].HeartRate;
            }
        }

        Console.WriteLine("Highest Heart Rate : " + max + " BPM");
    }

    // Sort records by heart rate
    static void SortHeartRate(PatientVital[] records)
    {
        PatientVital temp;

        for (int i = 0; i < records.Length - 1; i++)
        {
            for (int j = i + 1; j < records.Length; j++)
            {
                if (records[i].HeartRate > records[j].HeartRate)
                {
                    temp = records[i];
                    records[i] = records[j];
                    records[j] = temp;
                }
            }
        }

        Console.WriteLine("========== Heart Rate (Ascending Order) ==========\n");

        foreach (PatientVital patient in records)
        {
            Console.WriteLine(patient.HeartRate + " BPM");
        }
    }

    // Find median heart rate
    static void FindMedianHeartRate(PatientVital[] records)
    {
        Console.WriteLine("========== Median Heart Rate ==========\n");

        if (records.Length % 2 == 1)
        {
            int middle = records.Length / 2;

            Console.WriteLine("Median Heart Rate : " +records[middle].HeartRate + " BPM");
        }
        else
        {
            int middle1 = records.Length / 2 - 1;
            int middle2 = records.Length / 2;

            double median =
                (records[middle1].HeartRate +records[middle2].HeartRate) / 2.0;

            Console.WriteLine("Median Heart Rate : " + median + " BPM");
        }
    }

    // Sliding Window Average (Window Size = 3)
    static void SlidingWindowAverage(PatientVital[] records)
    {
        Console.WriteLine("========== Sliding Window Average ==========\n");

        int windowSize = 3;

        for (int i = 0; i <= records.Length - windowSize; i++)
        {
            int sum = 0;

            for (int j = i; j < i + windowSize; j++)
            {
                sum += records[j].HeartRate;
            }

            double average = (double)sum / windowSize;

            Console.WriteLine("Window " + (i + 1));

            Console.WriteLine("Average Heart Rate : " +average + " BPM");

            if (average > 100)
            {
                Console.WriteLine("Alert : High Average Heart Rate");
            }

            Console.WriteLine();
        }
    }
}