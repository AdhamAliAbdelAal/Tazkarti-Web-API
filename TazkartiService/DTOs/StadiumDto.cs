﻿using System.Text.Json.Serialization;

namespace TazkartiService.DTOs;

public class StadiumDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("capacity")]
    public int Capacity { get; set; }
    
    [JsonPropertyName("vipWidth")]
    public int VIPWidth { get; set; }

    [JsonPropertyName("vipLength")] 
    public int VIPLength { get; set; }
}