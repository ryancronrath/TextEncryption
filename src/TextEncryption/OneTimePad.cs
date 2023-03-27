using System.Text;

namespace TextEncryption;

/// <summary>
/// Encrypt and Decrypt text using the One Time Pad method.
/// </summary>
public class OneTimePad
{
    /// <summary>
    /// A list of valid characters which can be used to generate a random key and are used to encrypt and decrypt text.
    /// </summary>
    private readonly List<char> characters = new()
    {
        'a',
        'b',
        'c',
        'd',
        'e',
        'f',
        'g',
        'h',
        'i',
        'j',
        'k',
        'l',
        'm',
        'n',
        'o',
        'p',
        'q',
        'r',
        's',
        't',
        'u',
        'v',
        'w',
        'x',
        'y',
        'z',
        'A',
        'B',
        'C',
        'D',
        'E',
        'F',
        'G',
        'H',
        'I',
        'J',
        'K',
        'L',
        'M',
        'N',
        'O',
        'P',
        'Q',
        'R',
        'S',
        'T',
        'U',
        'V',
        'W',
        'X',
        'Y',
        'Z',
        '0',
        '1',
        '2',
        '3',
        '4',
        '5',
        '6',
        '7',
        '8',
        '9',
        '`',
        '-',
        '=',
        '~',
        '!',
        '@',
        '#',
        '$',
        '%',
        '^',
        '&',
        '*',
        '(',
        ')',
        '_',
        '+',
        '[',
        ']',
        '{',
        '}',
        '\\',
        '|',
        ',',
        '.',
        '/',
        '<',
        '>',
        '?',
        ';',
        '\'',
        ':',
        '"',
        ' '
    };

    /// <summary>
    /// Modular value of the characters list.
    /// </summary>
    private readonly int mod;

    public OneTimePad()
    {
        mod = characters.Count;
    }

    /// <summary>
    /// Encrypt a text value using a given key.
    /// </summary>
    /// <param name="text">The text you want to encrypt</param>
    /// <param name="key">The key used to encrypt the text value.</param>
    /// <returns>Encrypted text value as a string.</returns>
    /// <exception cref="ArgumentException"></exception>
    public string Encrypt(string text, string key)
    {
        // Null guards
        if (text == null) throw new NullReferenceException("Text value cannot be null");
        if (key == null) throw new NullReferenceException("Key value cannot be null");

        // Check that the key value is at least as long as the text value.
        if (key.Length < text.Length) throw new ArgumentException("Key must be at least as long as the text you want to encrypt.");

        // Replace new lines, tabs, and return with an empty string.
        text.Replace("\n", string.Empty);
        text.Replace("\t", string.Empty);
        text.Replace("\r", string.Empty);

        StringBuilder encryptedText = new();
        for (int i = 0; i < text.Length; i++)
        {
            var textIndex = characters.IndexOf(text[i]);
            var keyIndex = characters.IndexOf(key[i]);
            var sum = textIndex + keyIndex;
            var encryptedIndex = sum % mod;
            var encryptedValue = characters[encryptedIndex];
            encryptedText.Append(encryptedValue);
        }

        return encryptedText.ToString();
    }

    /// <summary>
    /// Decrypt a text value using a given key.
    /// </summary>
    /// <param name="text">The test you want to decrypt.</param>
    /// <param name="key">The key which is used to decrypt the text value.</param>
    /// <returns>Decrypted text value as a string.</returns>
    /// <exception cref="ArgumentException"></exception>
    public string Decrypt(string text, string key)
    {
        // Check that the key value is at least as long as the text value.
        if (key.Length < text.Length) throw new ArgumentException("Key must be at least as long as the text you want to decrypt.");

        StringBuilder decryptedText = new();
        for (int i = 0; i < text.Length; i++)
        {
            var textIndex = characters.IndexOf(text[i]);
            var keyIndex = characters.IndexOf(key[i]);
            var sum = textIndex - keyIndex;
            var encryptedIndex = sum % mod;

            // If negative add mod value to encryptedIndex to get actual index.
            encryptedIndex = (encryptedIndex < 0) ? (encryptedIndex + mod) : encryptedIndex;
            var encryptedValue = characters[encryptedIndex];
            decryptedText.Append(encryptedValue);
        }
        return decryptedText.ToString();
    }

    /// <summary>
    /// Create a random text value that can be used as a key for encrypting and decrypting test.
    /// </summary>
    /// <param name="length">The length of a key you would like to generate.</param>
    /// <returns>Key text value as a string.</returns>
    /// <exception cref="ArgumentException"></exception>
    public string GenerateKey(int length)
    {
        // Make sure length is a postive interger.
        if (length <= 0) throw new ArgumentException("Length must be greater than 0.");

        Random r = new();
        StringBuilder key = new();
        for (int i = 0; i < length; i++)
        {
            key.Append(characters[r.Next(0, characters.Count)]);
        }
        return key.ToString();
    }
}