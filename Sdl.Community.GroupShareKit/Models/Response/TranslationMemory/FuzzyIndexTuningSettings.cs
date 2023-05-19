namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class FuzzyIndexTuningSettings
    {
        /// <summary>
        /// Gets or sets min score increase number
        /// </summary>
        public int MinScoreIncrease { get; set; }
        /// <summary>
        /// Gets or sets source min search vector char length 
        /// </summary>
        public int MinSearchVectorLengthSourceCharIndex { get; set; }
        /// <summary>
        /// Gets or sets source min search vector word length
        /// </summary>

        public int MinSearchVectorLengthSourceWordIndex { get; set; }
        /// <summary>
        /// Gets or sets target min search vector char length 
        /// </summary>
        public int MinSearchVectorLengthTargetCharIndex { get; set; }
        /// <summary>
        /// Gets or sets target min search vector word length
        /// </summary>
        public int MinSearchVectorLengthTargetWordIndex { get; set; }
    }
}
