using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;
using Sdl.Community.GroupShareKit.Models.Response;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients
{
    public class TranslateAndAnalysisClient : ApiClient, ITranslateAndAnalysis
    {
        public TranslateAndAnalysisClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        /// <summary>
        /// Initiates a new translate and analysis job
        /// </summary>
        /// <param name="analysisOptions">The analysis options.</param>
        /// <returns>The job identifier</returns>
        /// <response code="200">The job was registered.</response>
        /// <response code="401">The authorization provided was denied. Populate the Authorization header with a valid token.</response>
        public Task<int> GetTranslateAndAnalysisJob(TranslationAndAnalysisJobRequest request)
        {
            return ApiConnection.Post<int>(ApiUrls.InitiateTranslateAndAnalysisJob(), request, "application/json");
        }

        /// <summary>
        /// Gets a new translation job for the specified translate and analysis job.
        /// </summary>
        /// <param name="jobId">The job identifier.</param>
        /// <returns>The translatable document identifier</returns>
        /// <response code="200">Translation triggered successfully.</response>
        /// <response code="400">When the given document or translation information not correct</response>
        /// <response code="404">If there is no document with the given identifier</response>
        public Task<int> GetTranslationJob(string jobId, MultipartFormDataContent request)
        {
            return ApiConnection.Post<int>(ApiUrls.TranslationJob(jobId), request, "multipart/form-data");
        }

        /// <summary>
        /// Exposes the translation status
        /// </summary>
        /// <param name="documentId">The document identifier.</param>
        /// <returns>The translation status and errors</returns>
        /// <response code="200">The status was returned.</response>
        /// <response code="404">If there is no document with the given identifier</response>
        public Task<Translation> GetTranslationStatus(string translateJob)
        {
            return ApiConnection.Get<Translation>(ApiUrls.TranslationJobStatus(translateJob), null);
        }

        /// <summary>
        /// Downloads the translated document.
        /// </summary>
        /// <param name="documentId">The document identifier.</param>
        /// <returns>The document content</returns>
        /// <response code="200">The download was successful</response>
        /// <response code="400">When the translation was not completed successfully. Use the status call to know the status of the translation.</response>
        /// <response code="404">If there is no document with the given identifier</response>
        public Task<byte[]> DownloadTranslationDocument(string translateJob)
        {
            return ApiConnection.Get<byte[]>(ApiUrls.DownloadTranslationDocument(translateJob),null);
        }

        /// <summary>
        /// Triggers the analysis.
        /// This should be called after all the translations are complete.
        /// </summary>
        /// <param name="jobId">The job identifier.</param>
        /// <returns>The analysis identifier</returns>
        /// <response code="200">The translated document identifier</response>
        /// <response code="400">When the given document or translation information is incorrect</response>
        public Task<int> GetAnalysisJob(string jobId)
        {
            return ApiConnection.Post<int>(ApiUrls.AnalysisJob(jobId), "", "application/json");
        }

        /// <summary>
        /// Exposes the status of the given analysis job.
        /// </summary>
        /// <param name="analysisId">The analysis identifier.</param>
        /// <response code="200">The status was returned.</response>
        /// <response code="404">If there is no analysis with the given identifier</response>
        public Task<Analysis> GetAnalysisStatus(string analysisJob)
        {
            return ApiConnection.Get<Analysis>(ApiUrls.AnalysisJobStatus(analysisJob), null);
        }
    }
}
