export function useFormattedDate() {
  function formatTimestamp(
    isoString: string,
    locale = "en-US",
    options?: Intl.DateTimeFormatOptions
  ): string {
    const date = new Date(isoString);
    return date.toLocaleString(locale, options);
  }

  return { formatTimestamp };
}
