﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using ImdbAPITicketOffice.Lib;
//
//    var inTheatersJson = InTheatersJson.FromJson(jsonString);

namespace ImdbAPITicketOffice.Lib
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class InTheatersJson
    {
        [JsonProperty("items")]
        public List<Item> Items { get; set; }

        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }
    }

    public partial class Item
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("fullTitle")]
        public string FullTitle { get; set; }

        [JsonProperty("year")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Year { get; set; }

        [JsonProperty("releaseState")]
        public string ReleaseState { get; set; }

        [JsonProperty("image")]
        public Uri Image { get; set; }

        [JsonProperty("runtimeMins")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long RuntimeMins { get; set; }

        [JsonProperty("runtimeStr")]
        public string RuntimeStr { get; set; }

        [JsonProperty("plot")]
        public string Plot { get; set; }

        [JsonProperty("contentRating")]
        public string ContentRating { get; set; }

        [JsonProperty("imDbRating")]
        public string ImDbRating { get; set; }

        [JsonProperty("imDbRatingCount")]
        public string ImDbRatingCount { get; set; }

        [JsonProperty("metacriticRating")]
        public string MetacriticRating { get; set; }

        [JsonProperty("genres")]
        public string Genres { get; set; }

        [JsonProperty("genreList")]
        public List<GenreList> GenreList { get; set; }

        [JsonProperty("directors")]
        public string Directors { get; set; }

        [JsonProperty("directorList")]
        public List<RList> DirectorList { get; set; }

        [JsonProperty("stars")]
        public string Stars { get; set; }

        [JsonProperty("starList")]
        public List<RList> StarList { get; set; }
    }

    public partial class RList
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class GenreList
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public partial class InTheatersJson
    {
        public static InTheatersJson FromJson(string json) => JsonConvert.DeserializeObject<InTheatersJson>(json, ImdbAPITicketOffice.Lib.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this InTheatersJson self) => JsonConvert.SerializeObject(self, ImdbAPITicketOffice.Lib.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}