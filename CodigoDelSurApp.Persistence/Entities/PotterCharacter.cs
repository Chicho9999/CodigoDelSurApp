﻿namespace CodigoDelSurApp.Persistence.Entities
{
    public class PotterCharacter
    {
        public required string FullName { get; set; }
        public required string Nickname { get; set; }
        public required string HogwartsHouse { get; set; }
        public required string InterpretedBy { get; set; }
        public required string Image { get; set; }
        public required string Birthdate { get; set; }
    }

}
