using Sdl.Community.GroupShareKit.Models.Response;
using System.IO;
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

        /// <summary>
        /// Gets a new translation job specified translate and analysis job.
        /// </summary>
        /// <param name="jobId">Job identifier</param>
        /// <param name="request">The request body</param>
        /// <returns><see cref="int"/>Translation job identifier</returns>
        Task<int> GetTranslationJob(string jobId, MultipartFormDataContent request);

        /// <summary>
        /// Gets the status for a translation job.
        /// </summary>
        /// <param name="translateJobNo">The translation identifier</param>
        /// <returns><see cref="Translation"/>The translation status and errors messages</returns>
        Task<Translation> GetTranslationStatus(string translateJobNo);

        /// <summary>
        /// Downloads the translated document.
        /// </summary>
        /// <param name="translateJobNo">The translation identifier</param>
        /// <returns>The file content in byte[]</returns>
        Task<byte[]> DownloadTranslationDocument(string translateJobNo);

        /// <summary>
        /// Gets a new translation job specified translate and analysis job.
        /// </summary>
        /// <param name="jobId">The job identifier</param>
        /// <returns><see cref="int"/>The analysis identifier</returns>
        Task<int> GetAnalysisJob(string jobId);

        /// <summary>
        /// Gets the status for a analysis job.
        /// </summary>
        /// <param name="analysisJobNo">The analysis identifier.</param>
        /// <returns><see cref="Analysis"/>The analysis status and errors messages</returns>
        Task<Analysis> GetAnalysisStatus(string analysisJobNo);

        /// <summary>
        /// Gets the specified analysis statistics.
        /// </summary>
        /// <param name="analysisJobNo">The analysis identifier.</param>
        /// <returns><see cref="AnalysisStatistics"/>The analysis statistics</returns>
        Task<AnalysisStatistics> GetAnalysisStatistics(string analysisJobNo);

        /// <summary>
        /// Completes a translate and analysis task.
        /// All the resources associated with the given job will be deleted.
        /// </summary>
        /// <param name="jobId">The job identifier.</param>
        Task DeleteJob(string jobId);
    }
}
