using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sdl.Community.GroupShareKit.Models.Response
{
    public class ProjectSettingsV4 : ProjectSettingsV2
    {
        [JsonProperty(PropertyName = "segmentLock")]
        public IList<SegmentLockingSettings> SegmentLock { get; set; }

        [JsonProperty(PropertyName = "enableSegmentLockTask")]
        public bool? EnableSegmentLockTask { get; set; }
    }

    public class GeneralSettings
    {
        [JsonProperty("projectName")]
        public string ProjectName { get; set; }

        [JsonProperty("projectId")]
        public Guid ProjectId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("languageDirection")]
        public List<LanguageDirectionInfo> LanguageDirection { get; set; }

        [JsonProperty("serverProjectTemplate")]
        public ServerProjectTemplate ServerProjectTemplate { get; set; }
    }

    public class LanguageDirectionInfo
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("uniqueId")]
        public Guid UniqueId { get; set; }

        [JsonProperty("sourceLanguage")]
        public string SourceLanguage { get; set; }

        [JsonProperty("targetLanguage")]
        public string TargetLanguage { get; set; }
    }

    public class ServerProjectTemplate
    {
        [JsonProperty("serverTemplateId")]
        public Guid ServerTemplateId { get; set; }

        [JsonProperty("serverTemplateName")]
        public string ServerTemplateName { get; set; }
    }

    public class PerfectMatch
    {
        [JsonProperty("projectId")]
        public Guid ProjectId { get; set; }

        [JsonProperty("referenceProjects")]
        public List<ReferenceProjectInfo> ReferenceProjects { get; set; }
    }

    public class ReferenceProjectInfo
    {
        [JsonProperty("referenceId")]
        public long ReferenceId { get; set; }

        [JsonProperty("projectReferenceId")]
        public Guid ProjectReferenceId { get; set; }

        [JsonProperty("projectReferenceName")]
        public string ProjectReferenceName { get; set; }

        [JsonProperty("owningProjectId")]
        public Guid OwningProjectId { get; set; }

        [JsonProperty("lock")]
        public bool Lock { get; set; }
    }

    public class ProjectSettingsTermbase
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("entries")]
        public long Entries { get; set; }

        [JsonProperty("languages")]
        public List<ProjectSettingsTermbaseLanguage> Languages { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }

    public class ProjectSettingsTermbaseLanguage
    {
        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("index")]
        public string Index { get; set; }
    }

    public class Terminology
    {
        [JsonProperty("minimumMatchValue")]
        public long MinimumMatchValue { get; set; }

        [JsonProperty("searchDepth")]
        public long SearchDepth { get; set; }

        [JsonProperty("searchOrder")]
        public string SearchOrder { get; set; }
    }

    public class TranslationMemoryReference
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("langPairs")]
        public List<LangPair> LangPairs { get; set; }

        [JsonProperty("scope")]
        public List<string> Scope { get; set; }

        [JsonProperty("isForAllLanguagePairs")]
        public bool IsForAllLanguagePairs { get; set; }

        [JsonProperty("parentUri")]
        public string ParentUri { get; set; }

        [JsonProperty("isDeleted")]
        public bool IsDeleted { get; set; }
    }

    public class LangPair
    {
        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("target")]
        public string Target { get; set; }

        [JsonProperty("tuCount")]
        public long TuCount { get; set; }
    }
}
