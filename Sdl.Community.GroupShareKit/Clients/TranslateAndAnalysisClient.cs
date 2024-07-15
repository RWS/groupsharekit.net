using Sdl.Community.GroupShareKit.Helpers;
using Sdl.Community.GroupShareKit.Http;
using Sdl.Community.GroupShareKit.Models.Response;
using System;
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
        /// <param name="request">The analysis options.</param>
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
        /// <param name="request">The document and the tm's options</param>
        /// <returns>The translatable document identifier</returns>
        /// <response code="200">Translation triggered successfully.</response>
        /// <response code="400">When the given document or translation information not correct</response>
        /// <response code="404">If there is no document with the given identifier</response>
        [Obsolete("This method is obsolete. Call 'GetTranslationJob(int, MultipartFormDataContent)' instead.")]
        public Task<int> GetTranslationJob(string jobId, MultipartFormDataContent request)
        {
            return ApiConnection.Post<int>(ApiUrls.TranslationJob(jobId), request, "multipart/form-data");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<int> GetTranslationJob(int jobId, MultipartFormDataContent request)
        {
            return ApiConnection.Post<int>(ApiUrls.TranslationJob(jobId), request, "multipart/form-data");
        }

        [Obsolete("This method is obsolete. Call 'GetTranslationStatus(int)' instead.")]
        public Task<Translation> GetTranslationStatus(string translateJobNo)
        {
            return ApiConnection.Get<Translation>(ApiUrls.TranslationJobStatus(translateJobNo), null);
        }

        /// <summary>
        /// Exposes the translation status
        /// </summary>
        /// <param name="translateJobId">The document identifier.</param>
        /// <returns>The translation status and errors</returns>
        /// <response code="200">The status was returned.</response>
        /// <response code="404">If there is no document with the given identifier</response>
        public Task<Translation> GetTranslationStatus(int translateJobId)
        {
            return ApiConnection.Get<Translation>(ApiUrls.TranslationJobStatus(translateJobId), null);
        }

        [Obsolete("This method is obsolete. Call 'DownloadTranslationDocument(int)' instead.")]
        public Task<byte[]> DownloadTranslationDocument(string translateJobNo)
        {
            return ApiConnection.Get<byte[]>(ApiUrls.DownloadTranslationDocument(translateJobNo), null);
        }

        /// <summary>
        /// Downloads the translated document.
        /// </summary>
        /// <param name="translateJobNo">The document identifier.</param>
        /// <returns>The document content</returns>
        /// <response code="200">The download was successful</response>
        /// <response code="400">When the translation was not completed successfully. Use the status call to know the status of the translation.</response>
        /// <response code="404">If there is no document with the given identifier</response>
        public Task<byte[]> DownloadTranslationDocument(int translateJobNo)
        {
            return ApiConnection.Get<byte[]>(ApiUrls.DownloadTranslationDocument(translateJobNo), null);
        }

        [Obsolete("This method is obsolete. Call 'GetAnalysisJob(int)' instead.")]
        public Task<int> GetAnalysisJob(string jobId)
        {
            return ApiConnection.Post<int>(ApiUrls.AnalysisJob(jobId), string.Empty, "application/json");
        }

        /// <summary>
        /// Triggers the analysis.
        /// This should be called after all the translations are complete.
        /// </summary>
        /// <param name="jobId">The job identifier.</param>
        /// <returns>The analysis identifier</returns>
        /// <response code="200">The translated document identifier</response>
        /// <response code="400">When the given document or translation information is incorrect</response>
        public Task<int> GetAnalysisJob(int jobId)
        {
            return ApiConnection.Post<int>(ApiUrls.AnalysisJob(jobId), string.Empty, "application/json");
        }

        [Obsolete("This method is obsolete. Call 'GetAnalysisStatus(int)' instead.")]
        public Task<Analysis> GetAnalysisStatus(string analysisJobNo)
        {
            return ApiConnection.Get<Analysis>(ApiUrls.AnalysisJobStatus(analysisJobNo), null);
        }

        /// <summary>
        /// Exposes the status of the given analysis job.
        /// </summary>
        /// <param name="analysisJobNo">The analysis identifier.</param>
        /// <response code="200">The status was returned.</response>
        /// <response code="404">If there is no analysis with the given identifier</response>
        public Task<Analysis> GetAnalysisStatus(int analysisJobId)
        {
            return ApiConnection.Get<Analysis>(ApiUrls.AnalysisJobStatus(analysisJobId), null);
        }

        [Obsolete("This method is obsolete. Call 'GetAnalysisStatistics(int)' instead.")]
        public Task<AnalysisStatistics> GetAnalysisStatistics(string analysisJobNo)
        {
            return ApiConnection.Get<AnalysisStatistics>(ApiUrls.AnalysisStatistics(analysisJobNo), null);
        }

        /// <summary>
        /// Gets the specified analysis statistics.
        /// </summary>
        /// <param name="analysisJobNo">The analysis identifier.</param>
        /// <returns>The analysis statistics</returns>
        public Task<AnalysisStatistics> GetAnalysisStatistics(int jobId)
        {
            return ApiConnection.Get<AnalysisStatistics>(ApiUrls.AnalysisStatistics(jobId), null);
        }

        [Obsolete("This method is obsolete. Call 'DeleteJob(int)' instead.")]
        public Task DeleteJob(string jobId)
        {
            return ApiConnection.Delete(ApiUrls.DeleteJob(jobId));
        }

        /// <summary>
        /// Completes a translate and analysis task.
        /// All the resources associated with the given job will be deleted.
        /// </summary>
        /// <param name="jobId">The job identifier.</param>
        public Task DeleteJob(int jobId)
        {
            return ApiConnection.Delete(ApiUrls.DeleteJob(jobId));
        }
    }
}
