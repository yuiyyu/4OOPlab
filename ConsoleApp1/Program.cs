using AutoBogus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using WorkshopClasees.DataTransfer;
using Formatting = Newtonsoft.Json.Formatting;


class Program
{
    static void Main(string[] args)
    {
        var faker = AutoFaker.Create();

        var workshop = faker.Generate<WorkshopDTO>();

        SerializeWorkshopToJson(workshop, "workshop.json");

        var deserializedWorkshop = DeserializeWorkshopFromJson("workshop.json");
        Console.WriteLine(deserializedWorkshop);
    }

    static void SerializeWorkshopToJson(WorkshopDTO workshop, string filePath)
    {
        var json = JsonConvert.SerializeObject(workshop, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }

    static WorkshopDTO DeserializeWorkshopFromJson(string filePath)
    {
        var json = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<WorkshopDTO>(json);
    }
}