using Sdl.Community.GroupShareKit.Models.Response;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Clients
{
    /// <summary>
    /// A client for GroupShare's TranslateAndAnalysis API.
    /// </summary>
    public interface ITranslateAndAnalysis
    {
        /// <summary>
        /// Initiates a new translate and analysis job
        /// </summary>
        /// <param name="request">The request body</param>
        /// <returns><see cref="int"/>Job identifier</returns>
        Task<int> GetTranslateAndAnalysisJob(TranslationAndAnalysisJobRequest request);

        [Obsolete("This method is obsolete. Call 'GetTranslationJob(int, MultipartFormDataContent)' instead.")]
        Task<int> GetTranslationJob(string jobId, MultipartFormDataContent request);

        /// <summary>
        /// Gets a new translation job specified translate and analysis job.
        /// </summary>
        /// <param name="jobId">Job identifier</param>
        /// <param name="request">The request body</param>
        /// <returns><see cref="int"/>Translation job identifier</returns>
        Task<int> GetTranslationJob(int jobId, MultipartFormDataContent request);

        [Obsolete("This method is obsolete. Call 'GetTranslationStatus(int)' instead.")]
        Task<Translation> GetTranslationStatus(string translateJobNo);

        /// <summary>
        /// Gets the status for a translation job.
        /// </summary>
        /// <param name="translateJobId">The translation identifier</param>
        /// <returns><see cref="Translation"/>The translation status and errors messages</returns>
        Task<Translation> GetTranslationStatus(int translateJobId);

        [Obsolete("This method is obsolete. Call 'DownloadTranslationDocument(int)' instead.")]
        Task<byte[]> DownloadTranslationDocument(string translateJobNo);

        /// <summary>
        /// Downloads the translated document.
        /// </summary>
        /// <param name="translateJobNo">The translation identifier</param>
        /// <returns>The file content in byte[]</returns>
        Task<byte[]> DownloadTranslationDocument(int translateJobNo);

        [Obsolete("This method is obsolete. Call 'GetAnalysisJob(int)' instead.")]
        Task<int> GetAnalysisJob(string jobId);

        /// <summary>
        /// Triggers the analysis.
        /// This should be called after all the translations are complete.
        /// </summary>
        /// <param name="jobId">The job identifier.</param>
        /// <returns>The analysis identifier</returns>
        /// <response code="200">The translated document identifier</response>
        /// <response code="400">When the given document or translation information is incorrect</response>
        Task<int> GetAnalysisJob(int jobId);

        [Obsolete("This method is obsolete. Call 'GetAnalysisStatus(int)' instead.")]
        Task<Analysis> GetAnalysisStatus(string analysisJobNo);

        /// <summary>
        /// Gets the status for a analysis job.
        /// </summary>
        /// <param name="analysisJobId">The analysis identifier.</param>
        /// <returns><see cref="Analysis"/>The analysis status and errors messages</returns>
        Task<Analysis> GetAnalysisStatus(int analysisJobId);

        [Obsolete("This method is obsolete. Call 'GetAnalysisStatistics(int)' instead.")]
        Task<AnalysisStatistics> GetAnalysisStatistics(string analysisJobNo);

        /// <summary>
        /// Gets the specified analysis statistics.
        /// </summary>
        /// <param name="analysisJobNo">The analysis identifier.</param>
        /// <returns>The analysis statistics</returns>
        Task<AnalysisStatistics> GetAnalysisStatistics(int jobId);

        [Obsolete("This method is obsolete. Call 'DeleteJob(int)' instead.")]
        Task DeleteJob(string jobId);

        /// <summary>
        /// Completes a translate and analysis task.
        /// All the resources associated with the given job will be deleted.
        /// </summary>
        /// <param name="jobId">The job identifier.</param>
        Task DeleteJob(int jobId);
    }
}
