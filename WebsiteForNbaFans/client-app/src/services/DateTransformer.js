class DateTransformer {
    /**
   * Calculate age from birthdate
   * @param {String} birthDay - Birthdate in 'MM/DD/YYYY' format
   * @returns {Number} - Age
   */
    static getAge(birthDay) {
        const now = new Date();
        const bd = new Date(birthDay);
        let age = now.getFullYear() - bd.getFullYear();
        const monthDiff = now.getMonth() - bd.getMonth();
        if (monthDiff < 0 || (monthDiff === 0 && now.getDate() < bd.getDate())) {
            age--;
        }
        return age;
    }

    static toISOLocale(isoDate) {
        const date = new Date(isoDate);
        return date.toISOString();
    }


    static toCzLocale(isoDate) {
        const date = new Date(isoDate);
        const day = date.getDate();
        const month = date.getMonth() + 1; // Months are 0-based in JavaScript
        const year = date.getFullYear();

        // Pad single-digit day and month with a leading zero
        const paddedDay = day < 10 ? '0' + day : day;
        const paddedMonth = month < 10 ? '0' + month : month;

        return `${paddedDay}.${paddedMonth}.${year}`;
    }

    static yearsInLeague(startYear) {
        const currentYear = new Date().getFullYear();
        if (startYear === 0) {
            return 'rookie';            
        }

        return currentYear - startYear;
    }

    static toCzBirthdate(birthdate) {
        const date = new Date(birthdate);
        const formattedDate = new Intl.DateTimeFormat('cz-CS', {
            year: 'numeric',
            month: 'long',
            day: 'numeric',
        }).format(date);

        return formattedDate;
    }
}

export { DateTransformer }; 