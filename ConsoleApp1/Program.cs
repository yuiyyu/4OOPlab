using AutoBogus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using WorkshopClasees;
using WorkshopClasees.Converters;
using WorkshopClasees.DataTransfer;
using Formatting = Newtonsoft.Json.Formatting;


class Program
{
    static void Main(string[] args)
    {
        var faker = AutoFaker.Create();
        var workshop = faker.Generate<Workshop>();
        SerializeWorkshopToJson(workshop, "workshop.json");
        var deserializedWorkshop = DeserializeWorkshopFromJson("workshop.json");
        Console.WriteLine(deserializedWorkshop);
    }

    static void SerializeWorkshopToJson(Workshop workshop, string filePath)
    {
        //var json = JsonConvert.SerializeObject(workshop, Formatting.Indented);
        //File.WriteAllText(filePath, json);
        var dtoObj = WorkshopConverter.ToDTO(workshop);
        var jsonFile = JsonConvert.SerializeObject(dtoObj, Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText(filePath, jsonFile);
    }

    static Workshop DeserializeWorkshopFromJson(string filePath)
    {
        var json = File.ReadAllText(filePath);
        var dtoObj = JsonConvert.DeserializeObject<WorkshopDTO>(json);
        return WorkshopConverter.FromDTO(dtoObj); 
    }   
}