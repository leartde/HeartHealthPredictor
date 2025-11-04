export const riskLabel = (probability?: number): string => {
  if (probability === undefined || probability > 1 || probability < 0) {
    return "Invalid";
  }
  if (probability > 0.95) return "Critical Risk";
  if (probability > 0.8) return "High Risk";
  if (probability > 0.5) return "Moderate Risk";
  if (probability > 0.2) return "Low Risk";

  return "Very Low Risk";
};
