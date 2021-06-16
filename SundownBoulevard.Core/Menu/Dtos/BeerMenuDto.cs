using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SundownBoulevard.Core.Menu.Dtos
{
	//TODO: Consider cleaning up these dtos, just pasted via VS for now.

	public class BeerMenuDto
	{
		public Beer[] Property1 { get; set; }
	}

	public class Beer
	{
		[JsonPropertyName("id")] 
		public int Id { get; set; }
		[JsonPropertyName("name")] 
		public string Name { get; set; }
		[JsonPropertyName("tagline")] 
		public string Tagline { get; set; }
		[JsonPropertyName("first_brewed")] 
		public string First_brewed { get; set; }
		[JsonPropertyName("description")] 
		public string Description { get; set; }
		[JsonPropertyName("image_url")] 
		public string Image_url { get; set; }
		[JsonPropertyName("abv")] 
		public float Abv { get; set; }
		[JsonPropertyName("ibu")]
		public float? ibu { get; set; }
		[JsonPropertyName("target_fg")] 
		public int Target_fg { get; set; }
		[JsonPropertyName("target_og")] 
		public float Target_og { get; set; }
		[JsonPropertyName("ehc")]
		public int? ebc { get; set; }
		[JsonPropertyName("srm")]
		public float? srm { get; set; }
		[JsonPropertyName("ph")]
		public float? ph { get; set; }
		[JsonPropertyName("attenuation_level")] 
		public float Attenuation_level { get; set; }
		[JsonPropertyName("volume")] 
		public Volume Volume { get; set; }
		[JsonPropertyName("boil_volume")] 
		public Boil_Volume Boil_volume { get; set; }
		[JsonPropertyName("method")] 
		public Method Method { get; set; }
		[JsonPropertyName("ingredients")] 
		public Ingredients Ingredients { get; set; }
		[JsonPropertyName("food_paring")] 
		public string[] Food_pairing { get; set; }
		[JsonPropertyName("brewers_tips")] 
		public string Brewers_tips { get; set; }
		[JsonPropertyName("contributed_by")] 
		public string Contributed_by { get; set; }
	}

	public class Volume
	{
		[JsonPropertyName("value")] 
		public int Value { get; set; }
		[JsonPropertyName("unit")] 
		public string Unit { get; set; }
	}

	public class Boil_Volume
	{
		[JsonPropertyName("value")] 
		public int Value { get; set; }
		[JsonPropertyName("unit")] 
		public string Unit { get; set; }
	}

	public class Method
	{
		[JsonPropertyName("mash_temp")] 
		public Mash_Temp[] mash_temp { get; set; }
		[JsonPropertyName("fermentation")] 
		public Fermentation Fermentation { get; set; }
		[JsonPropertyName("twist")] 
		public string Twist { get; set; }
	}

	public class Fermentation
	{
		[JsonPropertyName("temp")] 
		public Temp Temp { get; set; }
	}


	public class Mash_Temp
	{
		[JsonPropertyName("temp")] 
		public Temp Temp { get; set; }
		[JsonPropertyName("duration")]
		public int? Duration { get; set; }
	}


	public class Ingredients
	{
		[JsonPropertyName("[]")] 
		public Malt[] malt { get; set; }
		[JsonPropertyName("[]")] 
		public Hop[] hops { get; set; }
		[JsonPropertyName("yeast")] 
		public string Yeast { get; set; }
	}


	public class Malt
	{
		[JsonPropertyName("name")] 
		public string Name { get; set; }
		[JsonPropertyName("amount")] 
		public Amount Amount { get; set; }
	}

	public class Amount
	{
		[JsonPropertyName("value")] 
		public float Value { get; set; }
		[JsonPropertyName("unit")] 
		public string Unit { get; set; }
	}
	public class Temp
	{
		[JsonPropertyName("value")] 
		public int Value { get; set; }
		[JsonPropertyName("unit")] 
		public string Unit { get; set; }
	}

	public class Hop
	{
		[JsonPropertyName("name")] 
		public string Name { get; set; }
		[JsonPropertyName("amount")] 
		public Amount Amount { get; set; }
		[JsonPropertyName("add")] 
		public string Add { get; set; }
		[JsonPropertyName("attribute")] 
		public string Attribute { get; set; }
	}

}
