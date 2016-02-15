using Spellfire.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Spellfire.Dal
{
    public class CardRepository : MyRepositoryBase<Card>, ICardRepository
    {
        private List<BoosterKey> _onlineBoosterKeys = new List<BoosterKey>()
                                                      {
                                                        BoosterKey.Chaos, 
                                                        BoosterKey.Conquest,
                                                        BoosterKey.Inquisition,
                                                        BoosterKey.Millennium 
                                                     };

        public CardRepository(SpellfireContext context)
            : base(context)
        {
        }

        public ICollection<Card> GetByName(string name, bool includeOnlineBoosters, params Expression<Func<Card, object>>[] includes)
        {

            var query = Context.Cards
                               .AddIncludes(includes)
                               .Where(x => x.Name.Contains(name));

            if (!includeOnlineBoosters)
            {
                query = query.Where(x => !_onlineBoosterKeys.Contains(x.BoosterKey));
            }

            return query.ToList();
        }

        public Card GetBySequenceNumber(int sequenceNumber, params Expression<Func<Card, object>>[] includes)
        {
            var card = Context.Cards
                              .AddIncludes(includes)
                              .FirstOrDefault(x => x.SequenceNumber == sequenceNumber);

            return card;
        }

        public Card GetByBoosterAndNumber(BoosterKey boosterKey, int number, params Expression<Func<Card, object>>[] includes)
        {
            var card = Context.Cards
                              .AddIncludes(includes)
                              .FirstOrDefault(x => x.BoosterKey == boosterKey && x.Number == number);

            return card;
        }

        //public ICollection<DailyCase> GetBySearchCriteria(Guid companyKey, Guid userProfileKey, int start, int? maxResults, 
        //    ICollection<DailyCaseSearchCriteria> searchCriteria, out int totalCount, bool excludeUnpublished, params Expression<Func<DailyCase, object>>[] includes)
        //{
        //    var patientSearchCriteria = new List<Expression<Func<DailyCase, bool>>>();

        //    var startDate = searchCriteria.Where(x => x.SearchCriteriaType == DailyCaseSearchCriteriaType.StartDate).FirstOrDefault();
        //    var endDate = searchCriteria.Where(x => x.SearchCriteriaType == DailyCaseSearchCriteriaType.EndDate).FirstOrDefault();

        //    if (startDate == null || endDate == null)
        //        throw new Exception("Start and end dates are required");

        //    var dateRange = new DateRange(DateTime.Parse(startDate.SearchCriteriaValue), DateTime.Parse(endDate.SearchCriteriaValue));

        //    var query = Context.DailyCases.Where(x => x.CompanyKey == companyKey && x.Date >= dateRange.Start && x.Date <= dateRange.End);

        //    foreach (var criteria in searchCriteria)
        //    {
        //        switch (criteria.SearchCriteriaType)
        //        {
        //            case DailyCaseSearchCriteriaType.Location:
        //                var taskKey = Guid.Parse(criteria.SearchCriteriaValue);
        //                query = query.Where(x => x.TaskKey == taskKey);
        //                break;

        //            case DailyCaseSearchCriteriaType.Supervisor:
        //                var supervisorKey = Guid.Parse(criteria.SearchCriteriaValue);

        //                // Since there is no direct relation between a DailyCase and a Supervisor
        //                // we get the supervisor's tasks for the Date and Company
        //                // to then filter the daily cases by these tasks
        //                var supervisors = Context.DailyStaffMemberLocations
        //                                         .Where(x => x.CompanyKey == companyKey
        //                                                  && x.StaffMemberKey == supervisorKey
        //                                                  && x.Date >= dateRange.Start
        //                                                  && x.Date <= dateRange.End);

        //                if (excludeUnpublished)
        //                {
        //                    supervisors = supervisors.Where(x => x.IsPublished);
        //                }

        //                var supervisorTaskKeys = supervisors.Select(x => x.Task.TaskKey);

        //                query = query.Where(x => supervisorTaskKeys.Contains(x.TaskKey));
        //                break;

        //            case DailyCaseSearchCriteriaType.Provider:
        //                var providerKey = Guid.Parse(criteria.SearchCriteriaValue);

        //                query = excludeUnpublished
        //                        ? query.Where(x => x.DailyCaseStaffMembers.Any(s => s.StaffMemberKey == providerKey && s.IsPublished))
        //                        : query.Where(x => x.DailyCaseStaffMembers.Any(s => s.StaffMemberKey == providerKey));
        //                break;

        //            case DailyCaseSearchCriteriaType.Surgeon:
        //                if (criteria.RequireExactMatch)
        //                    query = query.Where(x => x.Surgeon == criteria.SearchCriteriaValue);
        //                else
        //                    query = query.Where(x => x.Surgeon.Contains(criteria.SearchCriteriaValue));
        //                break;

        //            case DailyCaseSearchCriteriaType.Procedure:
        //                if (criteria.RequireExactMatch)
        //                    query = query.Where(x => x.Procedure == criteria.SearchCriteriaValue);
        //                else
        //                    query = query.Where(x => x.Procedure.Contains(criteria.SearchCriteriaValue));
        //                break;

        //            case DailyCaseSearchCriteriaType.TextField1:
        //                if (criteria.RequireExactMatch)
        //                    query = query.Where(x => x.TextField1 == criteria.SearchCriteriaValue);
        //                else
        //                    query = query.Where(x => x.TextField1.Contains(criteria.SearchCriteriaValue));
        //                break;

        //            case DailyCaseSearchCriteriaType.TextField2:
        //                if (criteria.RequireExactMatch)
        //                    query = query.Where(x => x.TextField2 == criteria.SearchCriteriaValue);
        //                else
        //                    query = query.Where(x => x.TextField2.Contains(criteria.SearchCriteriaValue));
        //                break;

        //            case DailyCaseSearchCriteriaType.TextField3:
        //                if (criteria.RequireExactMatch)
        //                    query = query.Where(x => x.TextField3 == criteria.SearchCriteriaValue);
        //                else
        //                    query = query.Where(x => x.TextField3.Contains(criteria.SearchCriteriaValue));
        //                break;

        //            case DailyCaseSearchCriteriaType.TextField4:
        //                if (criteria.RequireExactMatch)
        //                    query = query.Where(x => x.TextField4 == criteria.SearchCriteriaValue);
        //                else
        //                    query = query.Where(x => x.TextField4.Contains(criteria.SearchCriteriaValue));
        //                break;

        //            case DailyCaseSearchCriteriaType.TextField5:
        //                if (criteria.RequireExactMatch)
        //                    query = query.Where(x => x.TextField5 == criteria.SearchCriteriaValue);
        //                else
        //                    query = query.Where(x => x.TextField5.Contains(criteria.SearchCriteriaValue));
        //                break;

        //            case DailyCaseSearchCriteriaType.TextField6:
        //                if (criteria.RequireExactMatch)
        //                    query = query.Where(x => x.TextField6 == criteria.SearchCriteriaValue);
        //                else
        //                    query = query.Where(x => x.TextField6.Contains(criteria.SearchCriteriaValue));
        //                break;

        //            case DailyCaseSearchCriteriaType.TextField7:
        //                if (criteria.RequireExactMatch)
        //                    query = query.Where(x => x.TextField7 == criteria.SearchCriteriaValue);
        //                else
        //                    query = query.Where(x => x.TextField7.Contains(criteria.SearchCriteriaValue));
        //                break;

        //            case DailyCaseSearchCriteriaType.TextField8:
        //                if (criteria.RequireExactMatch)
        //                    query = query.Where(x => x.TextField8 == criteria.SearchCriteriaValue);
        //                else
        //                    query = query.Where(x => x.TextField8.Contains(criteria.SearchCriteriaValue));
        //                break;

        //            case DailyCaseSearchCriteriaType.TextField9:
        //                if (criteria.RequireExactMatch)
        //                    query = query.Where(x => x.TextField9 == criteria.SearchCriteriaValue);
        //                else
        //                    query = query.Where(x => x.TextField9.Contains(criteria.SearchCriteriaValue));
        //                break;

        //            case DailyCaseSearchCriteriaType.TextField10:
        //                if (criteria.RequireExactMatch)
        //                    query = query.Where(x => x.TextField10 == criteria.SearchCriteriaValue);
        //                else
        //                    query = query.Where(x => x.TextField10.Contains(criteria.SearchCriteriaValue));
        //                break;

        //            case DailyCaseSearchCriteriaType.Checkbox1:
        //                var checkbox1Value = bool.Parse(criteria.SearchCriteriaValue);
        //                query = query.Where(x => x.Checkbox1 == checkbox1Value);
        //                break;

        //            case DailyCaseSearchCriteriaType.Checkbox2:
        //                var checkbox2Value = bool.Parse(criteria.SearchCriteriaValue);
        //                query = query.Where(x => x.Checkbox2 == checkbox2Value);
        //                break;

        //            case DailyCaseSearchCriteriaType.Checkbox3:
        //                var checkbox3Value = bool.Parse(criteria.SearchCriteriaValue);
        //                query = query.Where(x => x.Checkbox3 == checkbox3Value);
        //                break;

        //            case DailyCaseSearchCriteriaType.Checkbox4:
        //                var checkbox4Value = bool.Parse(criteria.SearchCriteriaValue);
        //                query = query.Where(x => x.Checkbox4 == checkbox4Value);
        //                break;

        //            case DailyCaseSearchCriteriaType.Checkbox5:
        //                var checkbox5Value = bool.Parse(criteria.SearchCriteriaValue);
        //                query = query.Where(x => x.Checkbox5 == checkbox5Value);
        //                break;

        //            case DailyCaseSearchCriteriaType.Checkbox6:
        //                var checkbox6Value = bool.Parse(criteria.SearchCriteriaValue);
        //                query = query.Where(x => x.Checkbox6 == checkbox6Value);
        //                break;

        //            case DailyCaseSearchCriteriaType.PatientAge:
        //                patientSearchCriteria.Add(x => x.PatientAgeYears.HasValue && x.PatientAgeYears == int.Parse(criteria.SearchCriteriaValue));
        //                break;

        //            case DailyCaseSearchCriteriaType.PatientGender:
        //                patientSearchCriteria.Add(x => x.PatientGender.HasValue && x.PatientGender == criteria.SearchCriteriaValue[0]);
        //                break;

        //            case DailyCaseSearchCriteriaType.PatientLastName:
        //                patientSearchCriteria.Add(x => !string.IsNullOrEmpty(x.PatientLastName) && x.PatientLastName.IndexOf(criteria.SearchCriteriaValue, StringComparison.OrdinalIgnoreCase) != -1);
        //                break;

        //            case DailyCaseSearchCriteriaType.PatientFirstName:
        //                patientSearchCriteria.Add(x => !string.IsNullOrEmpty(x.PatientFirstName) && x.PatientFirstName.IndexOf(criteria.SearchCriteriaValue, StringComparison.OrdinalIgnoreCase) != -1);
        //                break;

        //            case DailyCaseSearchCriteriaType.PatientHomePhone:
        //                patientSearchCriteria.Add(x => !string.IsNullOrEmpty(x.PatientHomePhoneNumber) && x.PatientHomePhoneNumber.IndexOf(criteria.SearchCriteriaValue, StringComparison.OrdinalIgnoreCase) != -1);
        //                break;

        //            case DailyCaseSearchCriteriaType.PatientCellPhone:
        //                patientSearchCriteria.Add(x => !string.IsNullOrEmpty(x.PatientCellPhoneNumber) && x.PatientCellPhoneNumber.IndexOf(criteria.SearchCriteriaValue, StringComparison.OrdinalIgnoreCase) != -1);
        //                break;

        //            case DailyCaseSearchCriteriaType.PatientAlternatePhoneNumber:
        //                patientSearchCriteria.Add(x => !string.IsNullOrEmpty(x.PatientAlternatePhoneNumber) && x.PatientAlternatePhoneNumber.IndexOf(criteria.SearchCriteriaValue, StringComparison.OrdinalIgnoreCase) != -1);
        //                break;

        //            case DailyCaseSearchCriteriaType.PatientGuardianName:
        //                patientSearchCriteria.Add(x => !string.IsNullOrEmpty(x.PatientGuardianName) && x.PatientGuardianName.IndexOf(criteria.SearchCriteriaValue, StringComparison.OrdinalIgnoreCase) != -1);
        //                break;

        //            case DailyCaseSearchCriteriaType.PatientGuardianPhoneNumber:
        //                patientSearchCriteria.Add(x => !string.IsNullOrEmpty(x.PatientGuardianPhoneNumber) && x.PatientGuardianPhoneNumber.IndexOf(criteria.SearchCriteriaValue, StringComparison.OrdinalIgnoreCase) != -1);
        //                break;

        //            case DailyCaseSearchCriteriaType.PatientEmail:
        //                patientSearchCriteria.Add(x => !string.IsNullOrEmpty(x.PatientEmail) && x.PatientEmail.IndexOf(criteria.SearchCriteriaValue, StringComparison.OrdinalIgnoreCase) != -1);
        //                break;

        //            case DailyCaseSearchCriteriaType.PatientDOB:
        //                patientSearchCriteria.Add(x => x.PatientDateOfBirth.HasValue && x.PatientDateOfBirth.Value.Date == DateTime.Parse(criteria.SearchCriteriaValue).Date);
        //                break;

        //            case DailyCaseSearchCriteriaType.PatientMRN:
        //                patientSearchCriteria.Add(x => !string.IsNullOrEmpty(x.PatientMedicalRecordNumber) && x.PatientMedicalRecordNumber.IndexOf(criteria.SearchCriteriaValue, StringComparison.OrdinalIgnoreCase) != -1);
        //                break;

        //            case DailyCaseSearchCriteriaType.PatientClinicalNotes:
        //                patientSearchCriteria.Add(x => !string.IsNullOrEmpty(x.PatientClinicalNotes) && x.PatientClinicalNotes.IndexOf(criteria.SearchCriteriaValue, StringComparison.OrdinalIgnoreCase) != -1);
        //                break;

        //            case DailyCaseSearchCriteriaType.PatientExtraNotes:
        //                patientSearchCriteria.Add(x => !string.IsNullOrEmpty(x.PatientExtraNotes) && x.PatientExtraNotes.IndexOf(criteria.SearchCriteriaValue, StringComparison.OrdinalIgnoreCase) != -1);
        //                break;
        //        }
        //    }

        //    var tasks = TaskRepository.QueryViewableDailyAssignableTasks(Context, userProfileKey);

        //    query = (from dailyCase in query
        //             from dailyCaseStaffMember in dailyCase.DailyCaseStaffMembers.DefaultIfEmpty()
        //             join task in tasks
        //             on dailyCase.TaskKey equals task.TaskKey
        //             select dailyCase)
        //             .Distinct()
        //             .AddIncludes(includes);

        //    query = query.OrderBy(x => x.Date).ThenBy(x => x.StartTime).ThenBy(x => x.DailyCaseKey);

        //    List<DailyCase> filteredCases = null;
        //    if (patientSearchCriteria.Any())
        //    {
        //        var unfilteredResults = query.ToList().AsQueryable();

        //        foreach (var predicate in patientSearchCriteria)
        //        {
        //            unfilteredResults = unfilteredResults.Where(predicate);
        //        }

        //        unfilteredResults = unfilteredResults.Skip(start);

        //        if (maxResults.HasValue)
        //            unfilteredResults = unfilteredResults.Take(maxResults.Value);

        //        var results = unfilteredResults.ToList();

        //        totalCount = results.Count();
        //        filteredCases = results;
        //    }
        //    else
        //    {
        //        totalCount = query.Count();

        //        query = query.Skip(start);

        //        if (maxResults.HasValue)
        //            query = query.Take(maxResults.Value);

        //        filteredCases = query.ToList();
        //    }

        //    var viewableStaff = StaffMemberRepository.QueryViewableStaffByUserProfileKey(Context, userProfileKey).ToList();
        //    var viewableFilteredCases = filteredCases.Select(c =>
        //    {
        //        c.DailyCaseStaffMembers = c.DailyCaseStaffMembers.Where(dp => (!excludeUnpublished || dp.IsPublished) 
        //            && viewableStaff.Any(vs => vs.StaffMemberKey == dp.StaffMemberKey)).ToList();
        //        return c;
        //    }).ToList();

        //    return viewableFilteredCases;
        //}

    }
}