import type { NextFunction, Request, RequestHandler, Response } from "express";
import multer from "multer";

const MAX_RECOVERED_FORM_FIELD_BYTES = 2 * 1024 * 1024;
const MAX_RECOVERED_FORM_FIELDS = 256;

// BestHTTP.HTTPRequest automatically switches from URL encoding to multipart whenever any
// AddField value is longer than 256 characters. RequestBuffer's serialized `Requests` field and
// diagnostic/log payloads therefore use multipart even though they contain no uploaded files.
// Keep this parser fields-only and bounded; a gameplay request can never authorize a file upload.
const parseFieldsOnlyMultipart = multer({
  limits: {
    fieldNameSize: 128,
    fieldSize: MAX_RECOVERED_FORM_FIELD_BYTES,
    fields: MAX_RECOVERED_FORM_FIELDS,
    files: 0,
    parts: MAX_RECOVERED_FORM_FIELDS,
  },
}).none();

/** Parse only the multipart form variant emitted by the recovered BestHTTP AddField transport. */
export const parseRecoveredMultipartForm: RequestHandler = (
  req: Request,
  res: Response,
  next: NextFunction,
): void => {
  if (!req.is("multipart/form-data")) {
    next();
    return;
  }
  parseFieldsOnlyMultipart(req, res, next);
};
