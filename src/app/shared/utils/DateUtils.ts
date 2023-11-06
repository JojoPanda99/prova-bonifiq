export class DateUtils {
    public static DatetimeToDate(datetime: string): string {
        const date = new Date(datetime);
        return date.toISOString().split('T')[0];
    }

    public static formatViewDate(date: Date): string {
        return date.toISOString().split('T')[0].split('-').reverse().join('/');
    }
}